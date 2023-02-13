using Gosto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Interfaces
{
     public interface ILayoutService
    {
        Task<Dictionary<string, string>> GetSettingsAsync();
        Task<IEnumerable<BasketVM>> GetBasketVMsAsync();
     



    }
}
