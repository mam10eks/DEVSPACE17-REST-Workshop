﻿using System.ComponentModel;
using System.Runtime.Serialization;
using WebApiHypermediaExtensionsCore.Util.Enum;
using WebApiHypermediaExtensionsCore.Util.Repository;

namespace CustomerDemo.Domain.Customer
{
    public class CustomerQuery : QueryBase<CustomerSortProperties, CustomerFilter>
    {
        // required by Web Api to instanciate when a route is called
        public CustomerQuery()
        {
        }

        // copy constructor
        public CustomerQuery(CustomerQuery customerQuery) : base(customerQuery)
        {
        }

        public override QueryBase<CustomerSortProperties, CustomerFilter> Clone()
        {
            return new CustomerQuery(this);
        }
    }

    // Options for sorting
    [TypeConverter(typeof(AttributedEnumTypeConverter<CustomerSortProperties>))]
    public enum CustomerSortProperties
    {
        [EnumMember(Value = "Age")]
        Age,

        [EnumMember(Value = "Name")]
        Name
    }

    // Options for filtering
    public class CustomerFilter : IQueryFilter
    {
        public int? MinAge { get; set; }

        public CustomerFilter()
        {
        }

        // copy constructor
        public CustomerFilter(CustomerFilter other)
        {
            MinAge = other.MinAge;
        }

        public IQueryFilter Clone()
        {
            return new CustomerFilter(this);
        }
    }
}