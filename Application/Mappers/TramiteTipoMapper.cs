using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TramiteTipoMapper : ITramiteTipoMapper
    {
        public Task<List<TramiteAdopcionResponse>> GetTramiteAdopciones(List<TramiteAdopcion> adopciones)
        {
            List<TramiteAdopcionResponse> list = new List<TramiteAdopcionResponse>();
            foreach (var item in adopciones)
            {
                var response = new TramiteAdopcionResponse
                {
                    TramiteId = item.TramiteId,
                    AireLibre = item.AireLibre,
                    CantidadPersonas = item.CantidadPersonas,
                    Castrados = item.Castrados,
                    EdadHijoMenor = item.EdadHijoMenor,
                    HayChicos = item.HayChicos,
                    HayMascotas = item.HayMascotas,
                    HorasSolo = item.HorasSolo,
                    MotivoAdopcion = item.MotivoAdopcion,
                    PaseoXMes = item.PaseoXMes,
                    PropietarioInquilino = item.PropietarioInquilino,
                    Vacunados = item.Vacunados,
                    CabeceraTramiteId = item.CabeceraTramiteId
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }

        public Task<TramiteAdopcionResponse> TramiteAdopcionResponse(TramiteAdopcion adopcion)
        {
            var response = new TramiteAdopcionResponse
            {
                TramiteId = adopcion.TramiteId,
                AireLibre = adopcion.AireLibre,
                CantidadPersonas = adopcion.CantidadPersonas,
                Castrados = adopcion.Castrados,
                EdadHijoMenor = adopcion.EdadHijoMenor,
                HayChicos = adopcion.HayChicos,
                HayMascotas = adopcion.HayMascotas,
                HorasSolo = adopcion.HorasSolo,
                MotivoAdopcion = adopcion.MotivoAdopcion,
                PaseoXMes = adopcion.PaseoXMes,
                PropietarioInquilino = adopcion.PropietarioInquilino,
                Vacunados = adopcion.Vacunados,
                CabeceraTramiteId = adopcion.CabeceraTramiteId
            };
            return Task.FromResult(response);
        }

        public Task<List<TramiteTransitoResponse>> GetTramiteTransitos(List<TramiteTransito> transitos)
        {
            List<TramiteTransitoResponse> list = new List<TramiteTransitoResponse>();
            foreach (var item in transitos)
            {
                var response = new TramiteTransitoResponse
                {
                    PropietarioInquilino = item.PropietarioInquilino,
                    ActitudHaciaAnimales = item.ActitudHaciaAnimales,
                    Cantidadpersonas = item.Cantidadpersonas,
                    ChicosYEdad = item.ChicosYEdad,
                    DisponibilidadHoraria = item.DisponibilidadHoraria,
                    Emergencia = item.Emergencia,
                    Expectativa = item.Expectativa,
                    ExperienciaDeTransito = item.ExperienciaDeTransito,
                    HayMascotas = item.HayMascotas,
                    ManejoAnimal = item.ManejoAnimal,
                    MedioDeTransporte = item.MedioDeTransporte,
                    PoliticaOrganizacion = item.PoliticaOrganizacion,
                    RazonInteres = item.RazonInteres,
                    Rutina = item.Rutina,
                    Seguimiento = item.Seguimiento,
                    TiempoDeAcogida = item.TiempoDeAcogida,
                    TipoDeEspacio = item.TipoDeEspacio,
                    VacunadosCastrados = item.VacunadosCastrados,
                    CabeceraTramiteId = item.CabeceraTramiteId
                };
                list.Add(response);
            }
            return Task.FromResult(list);
        }


        public Task<TramiteTransitoResponse> TramiteTransitoResponse(TramiteTransito transito)
        {
            var response = new TramiteTransitoResponse
            {
                PropietarioInquilino = transito.PropietarioInquilino,
                ActitudHaciaAnimales = transito.ActitudHaciaAnimales,
                Cantidadpersonas = transito.Cantidadpersonas,
                ChicosYEdad = transito.ChicosYEdad,
                DisponibilidadHoraria = transito.DisponibilidadHoraria,
                Emergencia = transito.Emergencia,
                Expectativa = transito.Expectativa,
                ExperienciaDeTransito = transito.ExperienciaDeTransito,
                HayMascotas = transito.HayMascotas,
                ManejoAnimal = transito.ManejoAnimal,
                MedioDeTransporte = transito.MedioDeTransporte,
                PoliticaOrganizacion = transito.PoliticaOrganizacion,
                RazonInteres = transito.RazonInteres,
                Rutina = transito.Rutina,
                Seguimiento = transito.Seguimiento,
                TiempoDeAcogida = transito.TiempoDeAcogida,
                TipoDeEspacio = transito.TipoDeEspacio,
                VacunadosCastrados = transito.VacunadosCastrados,
                CabeceraTramiteId = transito.CabeceraTramiteId
            };

            return Task.FromResult(response);
        }



    }
}
