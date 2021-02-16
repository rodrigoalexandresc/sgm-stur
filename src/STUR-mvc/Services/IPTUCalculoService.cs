using Confluent.Kafka;
using STUR_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUR_mvc.Services
{
    public class IPTUCalculoService
    {
        readonly STURDBContext dbContext; 
        public IPTUCalculoService(STURDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IList<Imposto> CalcularIPTU(int anoBase, string inscricaoImovel)
        {
            var impostosCalculados = new List<Imposto>();
            var dataCalculo = new DateTime(anoBase, 2, 20);
            var propriedadesCalculo = SelecionarPropriedadas(anoBase, inscricaoImovel);

            foreach (var infoGeo in propriedadesCalculo.GroupBy(g => g.InscricaoImovel))
            {
                var ultimaInfoGeo = infoGeo.OrderByDescending(o => o.DataAtualizacao).FirstOrDefault();
                var chave = ImpostoChave.GerarChave(ultimaInfoGeo.InscricaoImovel, dataCalculo);

                var imposto = dbContext.Impostos.FirstOrDefault(w => w.Chave == chave) 
                    ?? new Imposto(ultimaInfoGeo.InscricaoImovel, dataCalculo);
                
                imposto.AreaConstruida = ultimaInfoGeo.AreaConstruida;
                imposto.AreaTerreno = ultimaInfoGeo.AreaTerreno;
                imposto.Descricao = "IPTU ano base " + anoBase;
                imposto.CalcularValor();

                impostosCalculados.Add(imposto);

                if (imposto.Id == 0)
                    dbContext.Impostos.Add(imposto);
                else
                    dbContext.Impostos.Update(imposto);

                dbContext.SaveChanges();

                NotificarImpostoCalculado(imposto);
            }

            return impostosCalculados;
        }

        private void NotificarImpostoCalculado(Imposto imposto)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            var producerBuilder = new ProducerBuilder<Null, Imposto>(config);
            producerBuilder.SetValueSerializer(new ImpostoSerializer());

            using (var producer = producerBuilder.Build())
            {
                try
                {
                    producer.Produce("stur_imposto_calculado", new Message<Null, Imposto>
                    {
                        Value = imposto
                    });
                }
                catch (ProduceException<Null, Imposto> e)
                {
                    throw e;
                }
            }
        }

        private IList<InfoGeo> SelecionarPropriedadas(int anoBase, string inscricaoImovel)
        {
            var propriedadesCalculo = new List<InfoGeo>();
            if (!string.IsNullOrEmpty(inscricaoImovel))
            {
                return dbContext.InformacoesGeograficas.Where(w => w.InscricaoImovel == inscricaoImovel && w.DataAtualizacao.Year <= anoBase).ToList();
            }
            
            return  dbContext.InformacoesGeograficas.Where(w => w.DataAtualizacao.Year <=  anoBase).ToList();
        }
    }
}
