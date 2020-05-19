using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VatanAPI.Core.Repositories;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Repositories;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Domain.Services
{
    public class SiparisService : ISiparisService
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SiparisService(ISiparisRepository siparisRepository, IUnitOfWork unitOfWork)
        {
            _siparisRepository = siparisRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Siparis>> ListAsync()
        {
            return await _siparisRepository.ListAsync();
        }
        public async Task<SiparisResponse> SaveAsync(Siparis siparis)
        {
            try
            {
                await _siparisRepository.AddAsync(siparis);
                await _unitOfWork.CompleteAsync();

                return new SiparisResponse(siparis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SiparisResponse($"An error occurred when saving the siparis: {ex.Message}");
            }
        }
        public async Task<SiparisResponse> UpdateAsync(int id, Siparis siparis)
        {
            var existingSiparis = await _siparisRepository.FindByIdAsync(id);

            if (existingSiparis == null)
                return new SiparisResponse("Siparis not found.");

            existingSiparis.SiparisId = siparis.SiparisId;

            try
            {
                _siparisRepository.Update(existingSiparis);
                await _unitOfWork.CompleteAsync();

                return new SiparisResponse(existingSiparis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SiparisResponse($"An error occurred when updating the siparis: {ex.Message}");
            }
        }
        public async Task<SiparisResponse> DeleteAsync(int id)
        {
            var existingSiparis = await _siparisRepository.FindByIdAsync(id);

            if (existingSiparis == null)
                return new SiparisResponse("Siparis not found.");

            try
            {
                _siparisRepository.Remove(existingSiparis);
                await _unitOfWork.CompleteAsync();

                return new SiparisResponse(existingSiparis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SiparisResponse($"An error occurred when deleting the siparis: {ex.Message}");
            }
        }

    }
}

