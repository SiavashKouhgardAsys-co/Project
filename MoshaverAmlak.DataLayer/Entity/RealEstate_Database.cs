using System;
using System.Collections.Generic;

namespace MoshaverAmlak.DataLayer.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDelete { get; set; }
    }
    public class HomeFile : BaseEntity
    {
        public string OwnerName { get; set; }
        public string OwnerNumber { get; set; }
        public string Address { get; set; }
        public long TotalPrice { get; set; }
        public long PartalPrice { get; set; }
        public long FinalPrice { get; set; }
        public string YearOfConstruction { get; set; }
        public double Area { get; set; }
        public bool IsParking { get; set; }
        public int ParkingCount { get; set; }
        public bool IsWarehouse { get; set; }
        public int WarehouseArea { get; set; }
        public bool IsBalcony { get; set; }
        public int BalconyArea { get; set; }
        public int Floor { get; set; }
        public int TotalNsumberOfFloors { get; set; }
        public int NumberOfUnitsPerFloor { get; set; }
        public bool IsEvacuated { get; set; }
        public bool IsQuickSale { get; set; }
        public int StreetWidth { get; set; }
        public string Description { get; set; }

        public int RegionId { get; set; }
        public int RoomId { get; set; }
        public int BalconyPlaceId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int RebuiltId { get; set; }
        public int CityId { get; set; }
        public int TypeHomeId { get; set; }
        public int HomeDirectionId { get; set; }
        public int CupboardId { get; set; }
        public int CWTypeId { get; set; }
        public int BuildingFacadeId { get; set; }
        public int FloorMaterialId { get; set; }
        public int DoorOpenerTypeId { get; set; }
        public int AirConditionerId { get; set; }
        public int HotWaterTypeId { get; set; }
        public int HeatingTypeId { get; set; }
        public int TypeOfDocumentId { get; set; }
        public int HomeFileTypeId { get; set; }
        public int FileTypeId { get; set; }

        public Region Region { get; set; }
        public Room Room { get; set; }
        public BalconyPlace BalconyPlace { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public Rebuilt Rebuilt { get; set; }
        public City City { get; set; }
        public TypeHome TypeHome { get; set; }
        public HomeDirection HomeDirection { get; set; }
        public Cupboard Cupboard { get; set; }
        public CWType CWType { get; set; }
        public BuildingFacade BuildingFacade { get; set; }
        public FloorMaterial FloorMaterial { get; set; }
        public DoorOpenerType DoorOpenerType { get; set; }
        public AirConditioner AirConditioner { get; set; }
        public HotWaterType HotWaterType { get; set; }
        public HeatingType HeatingType { get; set; }
        public TypeOfDocument TypeOfDocument { get; set; }
        public HomeFileType HomeFileType { get; set; }
        public FileType FileType { get; set; }

        public ICollection<ImageHome> ImageHomes { get; set; }
        public ICollection<FacilitiesHomeFile> FacilitiesHomeFiles { get; set; }
    }
    public class HomeFileType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class FileType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class Region : BaseEntity
    {
        public int Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
        public ICollection<UserRegion> UserRegions { get; set; }
    }
    public class Room : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class BalconyPlace : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class Neighbourhood : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class Rebuilt : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class City : BaseEntity
    {
        public int Name { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class Province : BaseEntity
    {
        public int Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
    public class TypeHome : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class ImageHome : BaseEntity
    {
        public string ImagePath { get; set; }

        public int HomeFileId { get; set; }

        public HomeFile HomeFile { get; set; }
    }
    public class HomeDirection : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class Cupboard : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class CWType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class BuildingFacade : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class FloorMaterial : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class DoorOpenerType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class AirConditioner : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class HotWaterType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class HeatingType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class TypeOfDocument : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HomeFile> HomeFiles { get; set; }
    }
    public class Facilities : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<FacilitiesHomeFile> FacilitiesHomeFiles { get; set; }
    }
    public class FacilitiesHomeFile : BaseEntity
    {
        public int FacilitiesId { get; set; }
        public int HomeFileId { get; set; }

        public Facilities Facilities { get; set; }
        public HomeFile HomeFile { get; set; }
    }
    public class UserRegion : BaseEntity
    {
        public string UserId { get; set; }
        public int RegionId { get; set; }

        public RealEstate_User RealEstate_User { get; set; }
        public Region Region { get; set; }
    }
    public class RealEstate : BaseEntity
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }

        public RealEstate_User RealEstate_User { get; set; }

        public ICollection<RealEstateAddress> RealEstateAddresses { get; set; }
        public ICollection<RealEstateTel> RealEstateTels { get; set; }
    }
    public class RealEstateAddress : BaseEntity
    {
        public string Address { get; set; }

        public int RealEstateId { get; set; }

        public RealEstate RealEstate { get; set; }
    }
    public class RealEstateTel : BaseEntity
    {
        public string Tel { get; set; }

        public int RealEstateId { get; set; }

        public RealEstate RealEstate { get; set; }
    }
    public class Owner : BaseEntity
    {
        public string FullName { get; set; }
        public string Descrption { get; set; }

        public string UserId { get; set; }

        public RealEstate_User RealEstate_User { get; set; }

        public ICollection<OwnerTel> OwnerTels { get; set; }
    }
    public class OwnerTel : BaseEntity
    {
        public string Tel { get; set; }

        public int OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
    public class Buyer : BaseEntity
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string AmountOfInvestiment { get; set; }

        public string UserId { get; set; }

        public RealEstate_User RealEstate_User { get; set; }

        public ICollection<BuyerTel> BuyerTels { get; set; }
    }
    public class BuyerTel : BaseEntity
    {
        public string Tel { get; set; }

        public int BuyerId { get; set; }

        public Buyer Buyer { get; set; }
    }
    public class Investor : BaseEntity
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string AmountOfInvestiment { get; set; }

        public string UserId { get; set; }

        public RealEstate_User RealEstate_User { get; set; }

        public ICollection<InvestorTel> BuyerTels { get; set; }
    }
    public class InvestorTel : BaseEntity
    {
        public string Tel { get; set; }

        public int InvestorId { get; set; }

        public Investor Investor { get; set; }
    }
    public class UserWorkArea : BaseEntity
    {
        public double MaxArea { get; set; }
        public double MinArea { get; set; }

        public string UserId { get; set; }

        public RealEstate_User RealEstate_User { get; set; }
    }
}
