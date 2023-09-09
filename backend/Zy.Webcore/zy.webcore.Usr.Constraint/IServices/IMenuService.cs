﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.IService;
using zy.webcore.Usr.Constraint.Dtos.Role;

namespace zy.webcore.Usr.Constraint.IServices
{
    /// <summary>
    /// 角色Service
    /// </summary>
    public interface IMenuService : IAppService
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppSrvResult<PageResDto<MenuOutputDto>>> GetListAsync(MenuSearchDto dto);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppSrvResult> AddAsync(MenuInputDto dto);
    }
}
