﻿using System;
using System.Collections.ObjectModel;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OwinDemo
{
    /// <summary>
    ///     This class is used to extend the default controller descriptor to add the action filters dynamically.
    /// </summary>
    public class DynamicHttpControllerDescriptor : HttpControllerDescriptor
    {
        /// <summary>
        ///     The Dynamic Controller Action filters.
        /// </summary>
        private readonly IFilter[] _filters;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicHttpControllerDescriptor" /> class. Add the argument for action
        ///     filters to the controller.
        /// </summary>
        /// <param name="configuration">The Http Configuration.</param>
        /// <param name="controllerName"> The controller name.</param>
        /// <param name="controllerType">The controller type.</param>
        /// <param name="filters">The Dynamic Controller action filters.</param>
        public DynamicHttpControllerDescriptor(HttpConfiguration configuration, string controllerName,
            Type controllerType, IFilter[] filters = null)
            : base(configuration, controllerName, controllerType)
        {
            _filters = filters;
        }

        /// <summary>
        ///     The overrides the GetFilters for the controller and adds the Dynamic Controller filters.
        /// </summary>
        /// <returns> The Collection of filters.</returns>
        public override Collection<IFilter> GetFilters()
        {
            var actionFilters = new Collection<IFilter>();

            if (_filters != null && _filters.Length > 0)
                foreach (var filter in _filters)
                    actionFilters.Add(filter);

            foreach (var baseFilter in base.GetFilters())
                actionFilters.Add(baseFilter);

            return actionFilters;
        }
    }
}