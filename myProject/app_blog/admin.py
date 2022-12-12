from django.contrib import admin
from django.shortcuts import get_object_or_404

from .forms import ArticleImageForm
from .models import Article, ArticleImage, Category


class CategoryAdmin(admin.ModelAdmin):
    list_display = ("category", )
    prepopulated_fields = {"slug": ("category", )}
    fieldsets = (
        ('', {
            "fields": ("category", "slug", ),
        }),
    )


class ArticleImageInline(admin.TabularInline):
    model = ArticleImage
    form = ArticleImageForm
    extra = 0

    fieldsets = (
        ('', {
            "fields": ("title", "image", ),
        }),
    )


class ArticleAdmin(admin.ModelAdmin):
    list_display = ("title", "pub_date", "slug", "main_page")
    inlines = [ArticleImageInline]
    multiupload_form = True
    multiupload_list = False
    prepopulated_fields = {"slug": ("title", )}
    raw_id_fields = ("category", )
    fieldsets = (
        ('', {
            "fields": ("pub_date", "category", "title", "description", "main_page"),
        }),
        ("Additionally", {
            "classes": ("grp-collapse grp-closed", ),
            "fields": ("slug", ),
        }),
    )

    def delete_file(self, pk, request):
        obj = get_object_or_404(ArticleImage, pk=pk)
        return obj.delete()


admin.site.register(Category, CategoryAdmin)
admin.site.register(Article, ArticleAdmin)
