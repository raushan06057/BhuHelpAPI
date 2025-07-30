﻿namespace BhuHelpAPI.Domain.IRepositories;

public interface IRoleRepository
{
    Task<ResponseModel> CreateAsync(ApplicationRole role);
    Task<ResponseModel> UpdateAsync(ApplicationRole role);
    Task<ResponseModel> DeleteAsync(ApplicationRole role);
    Task<ResponseModel> GetAsync(ApplicationRole role);
    Task<ResponseModel> GetAsync();
    Task<ResponseModel> GetAsync(string id);
}
