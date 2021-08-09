using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    /// <summary>
    /// интерфейс для маппинга
    /// </summary>
    /// <typeparam name="T">исходный тип объекта</typeparam>
    public interface IMapWith<T>
    {
        /// <summary>
        /// Создает конфигурацию из исходного типа T в тип назначения
        /// </summary>
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());

    }
}
