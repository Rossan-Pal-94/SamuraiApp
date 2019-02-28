﻿using SamuraiAppCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiAppCore.Domain
{
    public class SecretIdentity
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
    }
}
