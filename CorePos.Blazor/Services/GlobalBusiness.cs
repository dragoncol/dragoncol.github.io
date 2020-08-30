using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePos.Blazor.Services
{
    public class GlobalBusiness
    {
        public static string GetOrderType(CorePOSApi.Model.SaleMd sale)
        {
            string orderType = GetOrderTypeFromEnum((CorePOSApi.Model.TransactionTypes)sale.transactionTypeId);
            string strReturn = string.Empty;
            if (sale.voidSale != null)
            {
                strReturn = "Anulada " + orderType;
            }
            else
            {
                strReturn = orderType;
            }
            if (sale.transferSale != null)
            {
                strReturn = strReturn + "(" + sale.transferSale.annexWareHouseName + ")";
            }
            return strReturn;
        }

        public static string GetOrderTypeFromEnum(CorePOSApi.Model.TransactionTypes type)
        {
            switch (type)
            {
                case CorePOSApi.Model.TransactionTypes.BUY_ORDER:
                    return "Ingreso de Inventario";
                case CorePOSApi.Model.TransactionTypes.DEVOLUTION:
                    return "Devolucion de Cliente";
                case CorePOSApi.Model.TransactionTypes.TRANSLATE_OUT:
                    return "Traslado Salida";
                case CorePOSApi.Model.TransactionTypes.TRANSLATE_IN:
                    return "Traslado Ingreso";
                case CorePOSApi.Model.TransactionTypes.SALE_ORDER:
                    return "";
            }
            return string.Empty;
        }
    }
}
