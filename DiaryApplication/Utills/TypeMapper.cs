using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;
using DiaryApplication.Core.Model;

namespace DiaryApplication.Utills
{
    public static class TypeMapper
    {
        public static TypeDTO ConvertToDto(TypeEntity type)
        {
            return new TypeDTO(type.Id, type.Title);
        }
        public static IEnumerable<TypeDTO> ConvertToListDto(List<TypeEntity> types)
        {
            return types?.Select(ConvertToDto) ?? null;
        }
        public static TypeEntity ConvertFromDto(TypeDTO type)
        {
            return new TypeEntity(type.Id, type.Title);
        }
        public static IEnumerable<TypeEntity> ConvertFromListDto(List<TypeDTO> types)
        {
            return types?.Select(ConvertFromDto);
        }
    }
}
