﻿using AppGet.HostSystem;
using AppGet.Manifests;
using AppGet.Requirements.Specifications;
using FluentAssertions;
using NUnit.Framework;

namespace AppGet.Tests.Requirements
{
    [TestFixture]
    public class OsArchitectureSpecificationFixture : TestBase<OsArchitectureSpecification>
    {
        [Test]
        public void should_be_true_when_type_is_any()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(true);

            Subject.IsRequirementSatisfied(new Installer
            {
                Architecture = ArchitectureTypes.Any
            }).Success.Should().BeTrue();

        }

        [Test]
        public void should_be_true_when_type_is_x86()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(true);

            Subject.IsRequirementSatisfied(new Installer
                                           {
                                               Architecture = ArchitectureTypes.x86
                                           }).Success.Should().BeTrue();

        }

        [Test]
        public void should_be_true_when_type_is_x64_on_x64_os()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(true);

            Subject.IsRequirementSatisfied(new Installer
                                           {
                                               Architecture = ArchitectureTypes.x64
                                           }).Success.Should().BeTrue();
        }

        [Test]
        public void should_be_false_when_x64_on_x86_os()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.Is64BitOperatingSystem)
                  .Returns(false);

            Subject.IsRequirementSatisfied(new Installer
                                           {
                                               Architecture = ArchitectureTypes.x64
                                           }).Success.Should().BeFalse();
        }

        [Test]
        public void should_be_false_when_itanium()
        {
            Subject.IsRequirementSatisfied(new Installer
            {
                Architecture = ArchitectureTypes.Itanium
            }).Success.Should().BeFalse();
        }

        [Test]
        public void should_be_false_when_arm()
        {
            Subject.IsRequirementSatisfied(new Installer
            {
                Architecture = ArchitectureTypes.ARM
            }).Success.Should().BeFalse();
        }
    }
}
