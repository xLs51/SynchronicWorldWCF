using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class TypeContributionTranslation
    {
        public static TypeContributionDTO TypeContributionToDto(TypeContribution typeContribution)
        {
            return new TypeContributionDTO
            {
                TypeContributionId = typeContribution.TypeContributionId,
                Name = typeContribution.Name,
            };
        }

        public static TypeContribution DtoToTypeContribution(TypeContributionDTO typeContribution)
        {
            return new TypeContribution
            {
                TypeContributionId = typeContribution.TypeContributionId,
                Name = typeContribution.Name,
            };
        }
    }
}
