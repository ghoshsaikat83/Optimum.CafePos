﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimum.CafePos.Models
{
    public class ResponseModel<T>
    {
        public int Status;
        public string Message;
        public T Payload;
    }
}
