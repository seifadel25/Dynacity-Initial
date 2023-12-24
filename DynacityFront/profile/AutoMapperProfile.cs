using AutoMapper;
using DynacityFront.DTO;


namespace DynacityFront.profile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {








            CreateMap<UserDTO, UserCreateDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateDTO>().ReverseMap();

            CreateMap<UserDTO, UserShowDTO>().ReverseMap();
            CreateMap<Local_User_DTO, UserShowDTO>().ReverseMap();





            //allows you to explicitly define the mappings between the source and destination objects
            //creates a mapping from the Property entity to the PropertyDTO DTO and vice versa.
            //It uses the ForMember method to map the properties from the source to the destination,
            //where src is the source object and dest is the destination object.
            //It also uses a conditional statement to map the subtypes based on the PropertyType value.




            CreateMap<PropertyDTO, PropertyShowDTO22>().ReverseMap();
            CreateMap<PropertyDTO, PropertyCreateDTO>().ReverseMap();
            CreateMap<PropertyDTO, PropertyUpdateDTO>().ReverseMap();
            CreateMap<PropertyDTO, PropertyRentCreateDTO>().ReverseMap();
            CreateMap<SellDTO, PropertyDTO>().ReverseMap();
            CreateMap<SellShow, PropertyDTO>().ReverseMap();


           

            CreateMap<RentDTO, RentShowDTO>().ReverseMap();
            CreateMap<RentDTO, RentCreateDTO>().ReverseMap();
            CreateMap<RentDTO, RentUpdateDTO>().ReverseMap();
            CreateMap<RentDTO, RentCreateDTO>().ReverseMap();

            CreateMap<PropertyShowDTO, RentShowDTO>().ReverseMap();
            CreateMap<RentDTO, PropertyRentCreateDTO>().ReverseMap();
            CreateMap<RentCreateDTO, PropertyRentCreateDTO>().ReverseMap();
            CreateMap<PropertyCreateDTO, PropertyRentCreateDTO>().ReverseMap();

            CreateMap<BidsDTO, BidShowDTO>().ReverseMap();
            CreateMap<BidsDTO, BidsCreateDTO>().ReverseMap();
            CreateMap<BidsDTO, BidsUpdateDTO>().ReverseMap();
            CreateMap<BidsDTO, BidsCreateDTO>().ReverseMap();

            CreateMap<PropertyShowDTO, BidShowDTO>().ReverseMap();
            CreateMap<BidsDTO, PropertyBidCreateDTO>().ReverseMap();
            CreateMap<BidsCreateDTO, PropertyBidCreateDTO>().ReverseMap();
            CreateMap<PropertyCreateDTO, PropertyBidCreateDTO>().ReverseMap();

            CreateMap<SellDTO, SellShow>().ReverseMap();
            CreateMap<SellDTO, SellCreateDTO>().ReverseMap();
            CreateMap<SellDTO, SellUpdateDTO>().ReverseMap();
            CreateMap<SellDTO, SellCreateDTO>().ReverseMap();

            CreateMap<PropertyShowDTO, SellShow>().ReverseMap();
            CreateMap<SellDTO, PropertySellDTO>().ReverseMap();
            CreateMap<SellCreateDTO, PropertySellDTO>().ReverseMap();
            CreateMap<PropertyCreateDTO, PropertySellDTO>().ReverseMap();

            CreateMap<EventDTO, EventCreateDTO>().ReverseMap();
            CreateMap<EventDTO, EventUpdateDTO>().ReverseMap();
        }
    }
}
