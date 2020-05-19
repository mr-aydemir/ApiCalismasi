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
    public class SepetService : ISepetService
    {
        private readonly ISepetRepository _sepetRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SepetService(ISepetRepository sepetRepository, IUnitOfWork unitOfWork)
        {
            _sepetRepository = sepetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Sepet>> ListAsync()
        {
            return await _sepetRepository.ListAsync();
        }
        public async Task<SepetResponse> SaveAsync(Sepet sepet)
        {
            try
            {
                await _sepetRepository.AddAsync(sepet);
                await _unitOfWork.CompleteAsync();

                return new SepetResponse(sepet);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SepetResponse($"An error occurred when saving the sepet: {ex.Message}");
            }
        }
        public async Task<SepetResponse> UpdateAsync(int id, Sepet sepet)
        {
            var existingSepet = await _sepetRepository.FindByIdAsync(id);

            if (existingSepet == null)
                return new SepetResponse("Sepet not found.");

            existingSepet.SepetId = sepet.SepetId;

            try
            {
                _sepetRepository.Update(existingSepet);
                await _unitOfWork.CompleteAsync();

                return new SepetResponse(existingSepet);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SepetResponse($"An error occurred when updating the sepet: {ex.Message}");
            }
        }
        public async Task<SepetResponse> DeleteAsync(int id)
        {
            var existingSepet = await _sepetRepository.FindByIdAsync(id);

            if (existingSepet == null)
                return new SepetResponse("Sepet not found.");

            try
            {
                _sepetRepository.Remove(existingSepet);
                await _unitOfWork.CompleteAsync();

                return new SepetResponse(existingSepet);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SepetResponse($"An error occurred when deleting the sepet: {ex.Message}");
            }
        }

    }
}

