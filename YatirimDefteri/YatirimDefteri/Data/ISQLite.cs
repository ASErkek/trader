﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace YatirimDefteri.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
