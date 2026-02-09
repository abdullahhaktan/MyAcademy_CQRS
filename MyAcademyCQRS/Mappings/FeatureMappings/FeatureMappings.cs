using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.FeatureMappings
{
    public class FeatureMappings : Profile
    {
        public FeatureMappings()
        {
            CreateMap<Feature, GetFeaturesQueryResult>();
            CreateMap<Feature, GetFeatureByIdQueryResult>();
            CreateMap<UpdateFeatureCommand, Feature>();
            CreateMap<CreateFeatureCommand, Feature>();
        }
    }
}
