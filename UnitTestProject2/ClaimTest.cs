using Komodo_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsClaimValid()
        {
            Claims claim = new Claims();
            claim.IsValid = true;

            bool expected = true;
            bool actual = claim.IsValid;

            Assert.AreEqual(expected, actual);
        }

        public void WhatIsType()
        {
            Claims claim = new Claims();
            claim.TypeOfClaim = ClaimType.Car;

            ClaimType expected = ClaimType.Car;
            ClaimType actual = claim.TypeOfClaim;

            Assert.AreEqual(expected, actual);
        }
    }
}
