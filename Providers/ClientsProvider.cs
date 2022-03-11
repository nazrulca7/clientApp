using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using clientApp.Interfaces;
using clientApp.Models;


namespace clientApp.Prodivers
    {
    public class ClientsProvider : IClientProvider
    {
        private readonly ClinentContext DbContext;
        private readonly ILogger<ClientsProvider> ILogger;
     //   private readonly IMapper mapper;

        public ClientsProvider(ClinentContext dbContext, ILogger<ClientsProvider> Logger)
        {
            this.DbContext = dbContext;
            this.ILogger = Logger;
           


        }

        public async Task<(bool IsSuccess, string Message)> DeleteAsync(int? Id)
        {
            var Client = await DbContext.Client.FindAsync(Id);
            if (Client == null)
            {
                return (false, "Not Found");
            }

            DbContext.Client.Remove(Client);

            var result = await DbContext.SaveChangesAsync();

            return (result > 0, "Data Removed Successfully");
        }

        public async Task<(bool IsSuccess, IEnumerable<Client> client, string ErrorMessage)> GetAllClientsAsync()
        {
            try
            {
                var Clients = await DbContext.Client.ToListAsync();
                if (Clients != null && Clients.Any())
                {
                   
                    return (true, Clients, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                ILogger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Client> Client, string ErrorMessage)> GetClientByClientIdAsync(int Id)
        {

            try
            {
                var client = await DbContext.Client
                    .Where(o => o.Id == Id).ToListAsync();
                if (client != null && client.Any())
                {
                  
                    return (true, client, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                ILogger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, int Id, string Message)> InsertAsync(Client client)
        {
            //client.Id = await DbContext.Client.CountAsync() + 1;
            DbContext.Client.Add(client);
            var result = await DbContext.SaveChangesAsync();


            return (result > 0, client.Id, "Successfully Saved");
        }

        public async Task<(bool IsSuccess, int Id, string Message)> UpdateAsync(int Id, Client client)
        {
            var clients =  DbContext.Client.Where(o => o.Id == Id).FirstOrDefault();
            if (clients== null) {

                return (false, Id, "Not Found");

            }
            clients.FirstName = client.FirstName;
            clients.LastName = client.LastName;
            DbContext.Client.Update(clients);
            var result = await DbContext.SaveChangesAsync();

            return (result > 0, Id, "Updated Successfully");

        }
    
    }
}
