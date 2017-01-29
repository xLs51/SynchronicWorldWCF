using SynchronicWorldClass.DTO;
using SynchronicWorldClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Translation
{
    public class ContributionTranslation
    {
        public static ContributionDTO ContributionToDto(Contribution contribution)
        {
            return new ContributionDTO
            {
                ContributionId = contribution.ContributionId,
                Name = contribution.Name,
                Quantity = contribution.Quantity,
                TypeContributionId = contribution.TypeContributionId,
                PersonId = contribution.PersonId,
                EventId = contribution.EventId,
            };
        }

        public static Contribution DtoToContribution(ContributionDTO contribution)
        {
            return new Contribution
            {
                ContributionId = contribution.ContributionId,
                Name = contribution.Name,
                Quantity = contribution.Quantity,
                TypeContributionId = contribution.TypeContributionId,
                PersonId = contribution.PersonId,
                EventId = contribution.EventId,
            };
        }
    }
}
