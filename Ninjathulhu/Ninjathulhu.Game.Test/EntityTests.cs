using System;
using FluentAssertions;
using NUnit.Framework;

namespace Ninjathulhu.Game.Test
{
    [TestFixture]
    public class EntityComponentsTests
    {
        private class SomeComponent : Component
        {
            public Entity PeekEntity()
            {
                return Entity;
            }
        }

        Entity _entity;

        [SetUp]
        public void SetUp()
        {
            _entity = new Entity();
        }

        [Test]
        public void attaching_a_component_to_an_EntityComponents_associates_it_with_that_entity()
        {
            var component = _entity.Components.Attach<SomeComponent>() as SomeComponent;

            component.PeekEntity().Should().Be(_entity);
        }

        [Test]
        public void attaching_a_component_to_an_EntityComponents_is_idempotent()
        {
            var first = _entity.Components.Attach<SomeComponent>() as SomeComponent;
            var second = _entity.Components.Attach<SomeComponent>();

            second.Should().Be(first);
            first.PeekEntity().Should().Be(_entity);
        }

        [Test]
        public void get_works()
        {
            var component = _entity.Components.Attach<SomeComponent>() as SomeComponent;

            _entity.Components.Get<SomeComponent>().Should().Be(component);
            component.PeekEntity().Should().Be(_entity);
        }

        [Test]
        public void getting_a_component_type_that_has_not_been_registered_returns_null()
        {
            var entity = new Entity();
            entity.Components.Attach<Component>();

            entity.Components.Get<SomeComponent>().Should().BeNull();
        }

        [Test]
        public void removing_a_registered_component_works()
        {
            var entity = new Entity();
            var component = entity.Components.Attach<SomeComponent>() as SomeComponent;
            entity.Components.Remove<SomeComponent>();

            entity.Components.Get<SomeComponent>().Should().BeNull();
            component.PeekEntity().Should().BeNull();
        }

        [Test]
        public void removing_a_component_that_has_not_been_registered_does_not_throw()
        {
            var entity = new Entity();

            Action act = () => entity.Components.Remove<SomeComponent>();

            act.ShouldNotThrow();
        }
    }
}