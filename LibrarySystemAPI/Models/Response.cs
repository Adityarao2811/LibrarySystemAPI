﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystemAPI
{
    public class Response
    {
        public string Message;
        public Status Status;
    }

    public enum Status
    {
        Failure,
        Success
    }
}
