using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Ninjathulhu.Game.Test
{
    [TestFixture]
    public class PrefabTests
    {
        private class SomeComponent : Component
        {
            public Entity PeekEntity()
            {
                return Entity;
            }
        }

        [Test]
        public void defining_a_prefab_preserves_id()
        {
            var prefab = Prefab.Define("Foo", null);

            prefab.ID.Should().Be("Foo");
        }

        [Test]
        public void defining_a_prefab_preserves_components()
        {
            var components = new ComponentSet(
                new Dictionary <Type, ComponentProperties> {
                   { typeof(Component), null },
                   { typeof(SomeComponent), null }
                });

            var prefab = Prefab.Define("Foo", components);
            prefab.Components.Types.Should().BeEquivalentTo(components.Types);
        }

        [Test]
        public void spawning_an_entity_from_a_prefab_attaches_components()
        {
            var components = new ComponentSet(
                new Dictionary <Type, ComponentProperties> {
                    { typeof(Component), null },
                    { typeof(SomeComponent), null }
                });
            var prefab = Prefab.Define("Foo", components);

            var entity = Prefab.Spawn(prefab, null);

            entity.Components.Get<Component>().Should().NotBeNull();
            var somecomp = entity.Components.Get<SomeComponent>() as SomeComponent;
            somecomp.PeekEntity().Should().Be(entity);
        }
    }
}
