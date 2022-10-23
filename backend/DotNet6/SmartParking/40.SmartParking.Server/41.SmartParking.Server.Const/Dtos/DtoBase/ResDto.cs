using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： Res
///  Author: zy
///  Time:  2022-03-31 22:55:28
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.DtoBase
{
    /// <summary>
    /// 公共的返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResDto<T> : ResBaseDto
    {
        public ResDto(T? _data,string msg="")
        {
            if (_data is bool)
                Success = Convert.ToBoolean(_data);
            else if (_data is ValueTuple)
                Success = !_data.Equals(default);
            else
                Success = _data != null;
            if (Success)
                Code = ResCodeType.Success;
            Data = _data;
            Message = msg;
        }
        public ResDto()
        {

        }
        /// <summary>
        /// 数据
        /// </summary>
        public T? Data { get; set; }
    }

}
