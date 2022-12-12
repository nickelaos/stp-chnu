from django.db import models
from django.utils import timezone
from django.urls import reverse


class Category(models.Model):
    category = models.CharField("Category", max_length=250, help_text="Max length 250 symbols")
    slug = models.SlugField("Slug")

    objects = models.Manager()

    class Meta:
        verbose_name = "Category for publication"
        verbose_name_plural = "Category for publications"

    def get_absolute_url(self):
        try:
            url = reverse('articles-category-list', kwargs={'slug': self.slug})
        except:
            url = "/"
        return url

    def __str__(self):
        return self.category


class Article(models.Model):
    title = models.CharField("Caption", max_length=250, help_text="Max length 250 symbols")
    description = models.TextField(blank=True, verbose_name="Description")
    pub_date = models.DateTimeField("Publication`s date", default=timezone.now)
    slug = models.SlugField("Slug", unique_for_date="pub_date")
    main_page = models.BooleanField("Main Page", default=False, help_text="Show on main page")
    category = models.ForeignKey(Category, related_name="articles", blank=True, null=True, verbose_name="Category",
                                 on_delete=models.CASCADE)

    objects = models.Manager()

    class Meta:
        ordering = ["-pub_date"]
        verbose_name = "Article"
        verbose_name_plural = "Articles"

    def __str__(self):
        return self.title

    def get_absolute_url(self):
        try:
            url = reverse(
                'news-detail',
                kwargs={
                    "year": self.pub_date.strftime("%Y"),
                    "month": self.pub_date.strftime("%m"),
                    "day": self.pub_date.strftime("%d"),
                    "slug": self.slug
                    }
            )
        except:
            url = "/"
        return url


class ArticleImage(models.Model):
    article = models.ForeignKey(Article, verbose_name="Article", related_name="images", on_delete=models.CASCADE)
    image = models.ImageField("Photo", upload_to="photos")
    title = models.CharField("Caption", max_length=250, help_text="Max 250 symbols", blank=True)

    class Meta:
        verbose_name = "Photo for article"
        verbose_name_plural = "Photo for article"

    def __str__(self):
        return self.title

    @property
    def filename(self):
        return self.image.name.rsplit('/', 1)[-1]
