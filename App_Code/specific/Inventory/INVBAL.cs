using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PURBAL
/// </summary>
public class INVBAL
{
	public INVBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region variable
    string item_name;
    string quantity;
    string unit;
    string rate;
    string justification;
    string supplier_name;
    string address;
    string contact_no;
    string email;
    string remark;
    string store_name;
    string description;
    string status;
    string crg;
    string cat_name;
    string sub_cat_name;
    string cat_id;
    string key_id;
    string reorder_level;
    string identification;
    string sub_cat_id;
    string SessionuserId;
    string id;
    string typ;
    string item_id;
    string ven_id;
    string typ_id;
    string org_name;
    string pan_no;
    string vat_no;
    string tin_no;
    string excise_reg_no;
    string service_tax_no;
    string turnover;
    string fin_year;
    string city;
    string district;
    string state;
    string country;
    string pin;
    string tel_no;
    string mob_no;
    string website;
    string fax_no;
    string ac_no;
    string branch;
    string ifsc_code;
    string rtgs_code;
    string name;
    string designation;
    string path;
    string type_description;
    string org_mail_id;
    string doc_name;
    string org_tel_no;
    string org_mob_no;
    string org_add1;
    string org_add2;
    string org_citid;
    string org_mail_domain;
    string ver_mail_domain;
    string pur_no;
    string action_by;
    string forward_to;
    string req_no;
    string dept;
    string date;
    string tax;
    string discount;
    string amount;
    string order_data;
    string payment_data;
    string term_data;
    string ind_id;
    string to_date;
    string GRN_NO;
    string GRN_ID;
    string Bal_QTY;
    string Rtn_Item;
    #endregion

    #region defination

    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
    public string DocName
    {
        get
        {
            return doc_name;
        }
        set
        {
            doc_name = value;
        }
    }
    public string OrgMailId
    {
        get
        {
            return org_mail_id;
        }
        set
        {
            org_mail_id = value;
        }
    }
    public string TypeDescription
    {
        get
        {
            return type_description;
        }
        set
        {
            type_description = value;
        }
    }
    public string ItemName
    {
        get
        {
            return item_name;
        }
        set
        {
            item_name = value;
        }
    }

    public string Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            quantity = value;
        }
    }
    public string Unit
    {
        get
        {
            return unit;
        }
        set
        {
            unit = value;
        }
    }
    public string Rate
    {
        get
        {
            return rate;
        }
        set
        {
            rate = value;
        }
    }
    public string Justification
    {
        get
        {
            return justification;
        }
        set
        {
            justification = value;
        }
    }
    public string SupplierName
    {
        get
        {
            return supplier_name;
        }
        set
        {
            supplier_name = value;
        }
    }
    public string Address
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    public string ContactNo
    {
        get
        {
            return contact_no;
        }
        set
        {
            contact_no = value;
        }
    }
    public string EmailId
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }
    public string StoreName
    {
        get
        {
            return store_name;
        }
        set
        {
            store_name = value;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }
    public string Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }
    public string CRG
    {
        get
        {
            return crg;
        }
        set
        {
            crg = value;
        }
    }
    public string CatName
    {
        get
        {
            return cat_name;
        }
        set
        {
            cat_name = value;
        }
    }
    public string SubCatName
    {
        get
        {
            return sub_cat_name;
        }
        set
        {
            sub_cat_name = value;
        }
    }

    public string CatId
    {
        get
        {
            return cat_id;
        }
        set
        {
            cat_id = value;
        }
    }

    public string KeyId
    {
        get
        {
            return key_id;
        }
        set
        {
            key_id = value;
        }
    }
    public string ReorderLevel
    {
        get
        {
            return reorder_level;
        }
        set
        {
            reorder_level = value;
        }
    }
    public string Identification
    {
        get
        {
            return identification;
        }
        set
        {
            identification = value;
        }
    }
    public string SubCatId
    {
        get
        {
            return sub_cat_id;
        }
        set
        {
            sub_cat_id = value;
        }
    }
    public string SessionUserId
    {
        get
        {
            return SessionuserId;
        }
        set
        {
            SessionuserId = value;
        }
    }
    public string ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string Typ
    {
        get
        {
            return typ;
        }
        set
        {
            typ = value;
        }
    }
    public string ItemId
    {
        get
        {
            return item_id;
        }
        set
        {
            item_id = value;
        }
    }
    public string VenId
    {
        get
        {
            return ven_id;
        }
        set
        {
            ven_id = value;
        }
    }
    public string TypeId
    {
        get
        {
            return typ_id;
        }
        set
        {
            typ_id = value;
        }
    }
    public string OrgName
    {
        get
        {
            return org_name;
        }
        set
        {
            org_name = value;
        }
    }
    public string PanNo
    {
        get
        {
            return pan_no;
        }
        set
        {
            pan_no = value;
        }
    }
    public string VatNo
    {
        get
        {
            return vat_no;
        }
        set
        {
           vat_no = value;
        }
    }
    public string TinNo
    {
        get
        {
            return tin_no;
        }
        set
        {
            tin_no = value;
        }
    }
    public string Excise_Reg_No
    {
        get
        {
            return excise_reg_no;
        }
        set
        {
            excise_reg_no = value;
        }
    }
    public string Service_Tax_No
    {
        get
        {
            return service_tax_no;
        }
        set
        {
            service_tax_no = value;
        }
    }
    public string TurnOver
    {
        get
        {
            return turnover;
        }
        set
        {
            turnover = value;
        }
    }
    public string FinYear
    {
        get
        {
            return fin_year;
        }
        set
        {
            fin_year = value;
        }
    }
    public string City
    {
        get
        {
            return city;
        }
        set
        {
            city = value;
        }
    }
    public string District
    {
        get
        {
            return district;
        }
        set
        {
           district = value;
        }
    }
    public string State
    {
        get
        {
            return state;
        }
        set
        {
           state = value;
        }
    }
    public string Country
    {
        get
        {
            return country;
        }
        set
        {
            country = value;
        }
    }
    public string Pin
    {
        get
        {
            return pin;
        }
        set
        {
            pin = value;
        }
    }
    public string Tel_No
    {
        get
        {
            return tel_no;
        }
        set
        {
            tel_no = value;
        }
    }
    public string MobNo
    {
        get
        {
            return mob_no;
        }
        set
        {
            mob_no = value;
        }
    }
    public string FaxNo
    {
        get
        {
            return fax_no;
        }
        set
        {
            fax_no = value;
        }
    }
    public string Website
    {
        get
        {
            return website;
        }
        set
        {
            website = value;
        }
    }
    public string AcNo
    {
        get
        {
            return ac_no;
        }
        set
        {
            ac_no = value;
        }
    }
    public string Branch
    {
        get
        {
            return branch;
        }
        set
        {
            branch = value;
        }
    }
    public string IfscCode
    {
        get
        {
            return ifsc_code;
        }
        set
        {
            ifsc_code = value;
        }
    }
    public string RtgsCode
    {
        get
        {
            return rtgs_code;
        }
        set
        {
            rtgs_code = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public string Designation
    {
        get
        {
            return designation;
        }
        set
        {
            designation = value;
        }
    }

    public string OrgTelNo
    {
        get
        {
            return org_tel_no;
        }
        set
        {
           org_tel_no = value;
        }
    }

    public string OrgMobNo
    {
        get
        {
            return org_mob_no;
        }
        set
        {
            org_mob_no = value;
        }
    }

    public string OrgAdd1
    {
        get
        {
            return org_add1;
        }
        set
        {
            org_add1 = value;
        }
    }
    public string OrgAdd2
    {
        get
        {
            return org_add2;
        }
        set
        {
            org_add2 = value;
        }
    }
    public string OrgCitId
    {
        get
        {
            return org_citid;
        }
        set
        {
            org_citid = value;
        }
    }
    public string OrgMailDomain
    {
        get
        {
            return org_mail_domain;
        }
        set
        {
            org_mail_domain = value;
        }
    }
    public string VerMailDomain
    {
        get
        {
            return ver_mail_domain;
        }
        set
        {
            ver_mail_domain = value;
        }
    }
    public string PurNo
    {
        get
        {
            return pur_no;
        }
        set
        {
            pur_no = value;
        }
    }
    public string Remark
    {
        get
        {
            return remark;
        }
        set
        {
            remark = value;
        }
    }
    public string ActionBy
    {
        get
        {
            return action_by;
        }
        set
        {
            action_by = value;
        }
    }
    public string ForwardTo
    {
        get
        {
            return forward_to;
        }
        set
        {
            forward_to = value;
        }
    }
    public string ReqNo
    {
        get
        {
            return req_no;
        }
        set
        {
            req_no = value;
        }
    }
    public string Dept
    {
        get
        {
            return dept;
        }
        set
        {
            dept = value;
        }
    }
    public string Date
    {
        get
        {
            return date;
        }
        set
        {
            date = value;
        }
    }
    public string Tax
    {
        get
        {
            return tax;
        }
        set
        {
            tax = value;
        }
    }
    public string Discount
    {
        get
        {
            return discount;
        }
        set
        {
            discount = value;
        }
    }
    public string Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }
    public string OrderData
    {
        get
        {
            return order_data;
        }
        set
        {
            order_data = value;
        }
    }
    public string PaymentData
    {
        get
        {
            return payment_data;
        }
        set
        {
            payment_data = value;
        }
    }
    public string TermData
    {
        get
        {
            return term_data;
        }
        set
        {
            term_data = value;
        }
    }
    public string IndId 
    {
        get
        {
            return ind_id;
        }
        set
        {
            ind_id = value;
        }
    }

    public string ToDate
    {
        get
        {
            return to_date;
        }
        set
        {
            to_date = value;
        }
    }
    public string GrnNO
    {
        get
        {
            return GRN_NO;
        }
        set
        {
            GRN_NO = value;
        }
    }
    public string GRNID
    {
        get
        {
            return GRN_ID;
        }
        set
        {
            GRN_ID = value;
        }
    }
    public string BalQTY
    {
        get
        {
            return Bal_QTY;
        }
        set
        {
            Bal_QTY = value;
        }
    }
    public string RtnItem
    {
        get
        {
            return Rtn_Item;
        }
        set
        {
            Rtn_Item = value;
        }

    }
    #endregion
}