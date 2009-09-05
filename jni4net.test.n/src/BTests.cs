﻿using System;
using System.Collections.Generic;
using System.Text;
using java.lang;
using net.sf.jni4net.tested;
using net.sf.jni4net.utils;
using NUnit.Framework;
using Exception=System.Exception;

namespace net.sf.jni4net.test
{
    [TestFixture]
    public class BTests : TestBase
    {
        [Test]
        public void TypeString()
        {
            var value = "test";
            RegistryRecord record = Registry.Default.GetRecord(value);
            Assert.IsNotNull(record);
        }

        [Test]
        public void TypeInt()
        {
            var value = 1;
            RegistryRecord record = Registry.Default.GetRecord(value);
            Assert.IsNotNull(record);
        }

        [Test]
        public void TypeJInt()
        {
            RegistryRecord record = Registry.Default.GetRecord(Integer._class);
            Assert.IsNotNull(record);
        }

        [Test]
        public void TypeJInt2()
        {
            Integer i=new Integer(1);
            RegistryRecord record = Registry.Default.GetRecord(i);
            Assert.IsNotNull(record);
        }

        [Test]
        public void TypeEx()
        {
            var i = new Exception();
            RegistryRecord record = Registry.Default.GetRecord(i);
            Assert.IsNotNull(record);
        }

        [Test]
        public void TypeTh()
        {
            var i = new Throwable();
            RegistryRecord record = Registry.Default.GetRecord(i);
            Assert.IsNotNull(record);
        }

        private class MyClass : Runnable
        {
            public void run()
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void TypeNewIface()
        {
            MyClass val=new MyClass();
            RegistryRecord record = Registry.Default.GetRecord(val);
            Assert.IsNotNull(record);
        }

        [Test]
        public void TypeNewJIface()
        {
            JInterfacesHelper h = new JInterfacesHelper();
            var val = h.createJWithClrInterfaceExt(0);
            RegistryRecord record = Registry.Default.GetRecord(val);
            Assert.IsNotNull(record);
        }
    
    }
}