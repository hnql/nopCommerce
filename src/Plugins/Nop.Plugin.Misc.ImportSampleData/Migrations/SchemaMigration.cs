﻿using FluentMigrator;
using Nop.Data.Migrations;

namespace Nop.Plugin.Misc.ImportSampleData.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2021/05/17 12:00:00:5000001", "")]
    public class SchemaMigration : AutoReversingMigration
    {
        private readonly IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            Insert.IntoTable("LocationCategory").Row(new { Id=1, Name="Khách sạn" });
            Insert.IntoTable("LocationCategory").Row(new { Id=2, Name="Hoomstay" });
            Insert.IntoTable("LocationCategory").Row(new { Id=3, Name="Studio" });

            Insert.IntoTable("RoomType").Row(new { Id = 1, Name = "Thường" });
            Insert.IntoTable("RoomType").Row(new { Id = 2, Name = "Suite" });
            Insert.IntoTable("RoomType").Row(new { Id = 3, Name = "Presidental" });

            Insert.IntoTable("Location").Row(new { Id = 1, LocationCategoryId = 1, Name= "Khách sạn Huyền Vũ", Description= "Huyền Vũ Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 2, LocationCategoryId = 1, Name= "Khách sạn Song Phương", Description= "Song Phương Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 3, LocationCategoryId = 1, Name= "Khách sạn Sheraton", Description= "Sheraton Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 4, LocationCategoryId = 1, Name= "Khách sạn Bana", Description= "Bana Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 5, LocationCategoryId = 1, Name= "Khách sạn Song Han", Description= "Song Han Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 6, LocationCategoryId = 1, Name= "Khách sạn Riverfront", Description= "Riverfront Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=false });
            Insert.IntoTable("Location").Row(new { Id = 7, LocationCategoryId = 2,Name="Homestay Banana", Description= "Banana Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 8, LocationCategoryId = 2,Name="Homestay Apple", Description= "Banana Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 9, LocationCategoryId = 2,Name="Homestay Grape", Description= "Banana Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 10, LocationCategoryId = 3,Name="Studio Iron", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 11, LocationCategoryId = 3,Name="Studio Bronze", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 12, LocationCategoryId = 3,Name="Studio Silver", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });
            Insert.IntoTable("Location").Row(new { Id = 13, LocationCategoryId = 1,Name= "Khách sạn A cong", Description= "A cong Lorem ipsum dolor sit amet, cosectetur adipiscing elit. Mauris id nisi vel nisi volutpat iaculis nec non ante. Quisque nec diam a mi consectetur congue. Duis pulvinar ex vitae sapien pellentesque fermentum. Vivamus dapibus nisi est, gravida dictum metus finibus sit amet. Phasellus pellentesque dapibus magna, sollicitudin iaculis neque placerat et. Curabitur congue convallis neque sed tempus. Aenean gravida ante urna, id semper elit suscipit sit amet.",
                IsActive=true });

            Insert.IntoTable("Room").Row(new { Id = 1, LocationId = 1, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =45123, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 2, LocationId = 1, RoomTypeId = 2, Name = "Phòng Suite", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =2145, MaximumDate = 3, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 3, LocationId = 1, RoomTypeId = 3, Name = "Phòng Presidental", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4465, MaximumDate = 5, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 4, LocationId = 2, RoomTypeId = 2, Name = "Phòng Suite", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =45667, MaximumDate = 6, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 5, LocationId = 2, RoomTypeId = 3, Name = "Phòng Presidental", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4115, MaximumDate = 8, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 6, LocationId = 2, RoomTypeId = 3, Name = "Phòng Presidental", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =8475, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 7, LocationId = 3, RoomTypeId = 2, Name = "Phòng Suite", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =2345, MaximumDate = 1, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 8, LocationId = 4, RoomTypeId = 3, Name = "Phòng Presidental", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =8405, MaximumDate = 3, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 9, LocationId = 4, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4658, MaximumDate = 5, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 10, LocationId = 5, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4253, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 11, LocationId = 5, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4657, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 12, LocationId = 6, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4856, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 13, LocationId = 7, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =42151, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 14, LocationId = 7, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =43545, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 15, LocationId = 8, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =44451, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 16, LocationId = 9, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =41235, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 17, LocationId = 10, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =45565, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 18, LocationId = 11, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =48565, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 19, LocationId = 12, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =45675, MaximumDate = 2, IsActive = true});
            Insert.IntoTable("Room").Row(new { Id = 20, LocationId = 13, RoomTypeId = 1, Name = "Phòng thường", Description = "Proin dignissim, leo accumsan molestie bibendum, justo tortor auctor lacus, ut pharetra turpis elit vel lacus. Vestibulum laoreet pellentesque mi, ut sollicitudin arcu pretium eu. Vivamus a eros at eros auctor tincidunt. Nunc pulvinar erat velit, id sollicitudin risus luctus ut. Nam consequat sem augue, vel aliquam neque suscipit vitae. Phasellus elementum nibh dictum tellus sollicitudin, id dignissim quam iaculis. Nullam eu congue sem.",
                Price =4557, MaximumDate = 2, IsActive = false});
        }
    }
}
