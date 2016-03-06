﻿using NUnit.Framework;
using FluentAssertions;
using Ninjathulhu.Game;

namespace Ninjathulhu.Game.Test
{
    [TestFixture]
    public class ComponentTests
    {
        private class SomeComponent : Component
        {
            public Entity PeekEntity()
            {
                return Entity;
            }
        }

        [Test]
        public void attaching_a_component_to_an_entity_should_track_the_entity()
        {
            var comp = new SomeComponent();
            var entity = new Entity();

            comp.AttachTo(entity);

            comp.PeekEntity().Should().Be(entity);
        }

        [Test]
        public void removing_a_component_from_an_entity_should_reset_the_tracked_entity_to_null()
        {
            var comp = new SomeComponent();
            var entity = new Entity();

            comp.AttachTo(entity);
            comp.RemoveFrom(entity);

            comp.PeekEntity().Should().BeNull();
        }

        [Test]
        public void two_components_tracking_the_same_entity_should_be_siblings()
        {
            var foo = new SomeComponent();
            var bar = new SomeComponent();
            var entity = new Entity();

            foo.AttachTo(entity);
            bar.AttachTo(entity);

            (foo.IsSibling(bar) && bar.IsSibling(foo)).Should().BeTrue();
        }
    }
}
