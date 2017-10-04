﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SmartStore.Web.Framework.Modelling;
using SmartStore.Web.Framework;
using System.Web.Mvc;
using System.Web.Hosting;
using System.IO;

namespace SmartStore.GTPay.Models
{
    public abstract class GTPayInfoModelBase : ModelBase
    {
        public string DescriptionText { get; set; }
    }

    public class GTPayATMCardPaymentInfoModel : GTPayInfoModelBase
    {
        public string IconUrl { get; set; }
        public List<string> CardIconUrls { get; set; }
        //public string DescriptionText { get; set; }

        private const string CARD_FOLDER = "~/Plugins/SmartStore.GTPay/Content/card";


        //private readonly ICardIconManager _cardIconManager;

        public GTPayATMCardPaymentInfoModel()
        {
            CardIconUrls = GetAllCardIconUrl();
        }

        public List<string> GetAllCardIconUrl()
        {
            List<string> cardIcons = null;
            string folderPath = @"C:\Users\Dan\Documents\Visual Studio 2015\Projects\eStore\src\Plugins\SmartStore.GTPay\Content\card"; // HttpContext.Current.Server.MapPath(CARD_FOLDER);

            if (!Directory.Exists(folderPath))
            {
                return cardIcons;
            }

            IEnumerable<string> filePaths = Directory.EnumerateFiles(folderPath);
            if (filePaths != null && filePaths.Count() > 0)
            {
                cardIcons = new List<string>();

                filePaths = filePaths.OrderBy(x => x);
                foreach (string filePath in filePaths)
                {
                    FileInfo file = new FileInfo(filePath);
                    string fileVirtualPath = string.Format(CARD_FOLDER + "/{0}", file.Name);
                    cardIcons.Add(fileVirtualPath);
                }
            }

            return cardIcons;
        }


    }




}