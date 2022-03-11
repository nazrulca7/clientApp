using clientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clientApp.Interfaces
{
 
    public interface IClientProvider
    {

        Task<(bool IsSuccess, IEnumerable<Client> Client, String ErrorMessage)> GetClientByClientIdAsync(int Id);
        Task<(bool IsSuccess,  String Message)> DeleteAsync(int? Id);
        Task<(bool IsSuccess, int Id, String Message)> UpdateAsync(int Id,Client client);
        Task<(bool IsSuccess, int Id, String Message)> InsertAsync( Client client);
        Task<(bool IsSuccess, IEnumerable<Client> client, String ErrorMessage)> GetAllClientsAsync();
       
    }
}
