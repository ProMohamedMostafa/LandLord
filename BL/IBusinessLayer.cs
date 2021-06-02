using GenieLandLoardSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenieLandLoardSolution.BL
{
    public interface IBusinessLayer
    {
        Task<TbLandLoard> GetTbLandLoard(string domain);
        Task<bool> PutTbLandLoard(int id, TbLandLoard tbLandLoard);
        Task<TbLandLoard> PostTbLandLoard(TbLandLoard tbLandLoard);
        Task<bool> DeleteTbLandLoard(int id);
        bool TbLandLoardExists(int id);
    }
}
