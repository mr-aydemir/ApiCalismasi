﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VatanBilgisayarMobil.Services
{
    public interface IToolbarItemBadgeService
    {
        void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor);
    }
}
