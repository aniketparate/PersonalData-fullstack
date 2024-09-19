using PlayersDataWebApi.Models;

namespace PlayersDataWebApi.DAO
{
    public interface IPersonalInfoDao
    {
        Task<List<PersonalInfo>> GetAllPersonalInfo(string baseUri);
        Task<int> InsertPersonalDetails(InsertPersonalInfo personalInfo, string imageName);
        Task<string> DeletePersonalDetails(int id);
        Task<PersonalInfo> GetPersonalInfoById(int id, string baseUri);
        Task<int> UpdatePersonalInfo(int id, string residentialAddress, string permanentAddress, string phoneNumber);
    }
}
