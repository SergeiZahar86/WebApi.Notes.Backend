using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
