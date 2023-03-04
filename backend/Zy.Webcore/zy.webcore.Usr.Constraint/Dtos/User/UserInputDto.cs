using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.Dtos;

namespace zy.webcore.Usr.Constraint.Dtos.User
{
    public class UserOutputDto:OutputDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Account { get; set; } = null!;
    
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 职务ID
        /// </summary>
        public long? JobId { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
    }
}
