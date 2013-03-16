﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Glass.Mapper.Configuration;
using Glass.Mapper.Sc.Configuration;
using NUnit.Framework;

namespace Glass.Mapper.Sc.Tests.Configuration
{
    [TestFixture]
    public class SitecoreTypeConfigurationFixture
    {
        #region AutoMapProperty

        
        [Test]
        public void AutoMapProperty_MappingSitecoreInfo_ReturnsInfoConfig()
        {
            //Assign
            var typeConfig = new StubSitecoreTypeConfiguration();
            typeConfig.Type = typeof (StubClass);

            var prop = typeConfig.Type.GetProperty("Name");

            //Act
            var propConfig = typeConfig.StubAutoMapProperty(prop);

            //Assert
            Assert.IsTrue(propConfig is SitecoreInfoConfiguration);
            Assert.AreEqual(prop, propConfig.PropertyInfo);
        }

        [Test]
        public void AutoMapProperty_MappingSitecoreChildren_ReturnsChildrenConfig()
        {
            //Assign
            var typeConfig = new StubSitecoreTypeConfiguration();
            typeConfig.Type = typeof(StubClass);

            var prop = typeConfig.Type.GetProperty("Children");

            //Act
            var propConfig = typeConfig.StubAutoMapProperty(prop);

            //Assert
            Assert.IsTrue(propConfig is SitecoreChildrenConfiguration);
            Assert.AreEqual(prop, propConfig.PropertyInfo);
        }

        [Test]
        public void AutoMapProperty_MappingSitecoreParent_ReturnsParentConfig()
        {
            //Assign
            var typeConfig = new StubSitecoreTypeConfiguration();
            typeConfig.Type = typeof(StubClass);

            var prop = typeConfig.Type.GetProperty("Parent");

            //Act
            var propConfig = typeConfig.StubAutoMapProperty(prop);

            //Assert
            Assert.IsTrue(propConfig is SitecoreParentConfiguration);
            Assert.AreEqual(prop, propConfig.PropertyInfo);
        }

        [Test]
        public void AutoMapProperty_MappingSitecoreField_ReturnsFieldConfig()
        {
            //Assign
            var typeConfig = new StubSitecoreTypeConfiguration();
            typeConfig.Type = typeof(StubClass);

            var prop = typeConfig.Type.GetProperty("FieldName");

            //Act
            var propConfig = typeConfig.StubAutoMapProperty(prop);

            //Assert
            Assert.IsTrue(propConfig is SitecoreFieldConfiguration);
            Assert.AreEqual(prop, propConfig.PropertyInfo);
            Assert.AreEqual("FieldName", propConfig.CastTo<SitecoreFieldConfiguration>().FieldName);
        }

        #endregion
        #region Stubs


        public class StubSitecoreTypeConfiguration : SitecoreTypeConfiguration
        {
            public AbstractPropertyConfiguration StubAutoMapProperty(PropertyInfo property)
            {
               return base.AutoMapProperty(property);
            }
            
        }

        public class StubClass
        {
            public string Name { get; set; }
            public string Parent { get; set; }
            public string Children { get; set; }
            public string FieldName { get; set; }
        }

        #endregion

    }
}