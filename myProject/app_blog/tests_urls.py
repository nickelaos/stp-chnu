from django.test import TestCase
from django.urls import resolve, reverse
import datetime

from .views import ArticleCategoryList, ArticleDetail, ArticleList, HomePageView


class UrlsTests(TestCase):
    def test_home_view_status_code(self):
        url = reverse('home')
        response = self.client.get(url)
        self.assertEquals(response.status_code, 200)

    def test_home_url_resolves_home_view(self):
        view = resolve('/')
        self.assertEquals(view.func.view_class, HomePageView)

    def test_article_list_url_resolves_home_view(self):
        view = resolve('/articles/')
        self.assertEquals(view.func.view_class, ArticleList)

    def test_article_category_url_resolves_home_view(self):
        view = resolve('/articles/category/name/')
        self.assertEquals(view.func.view_class, ArticleCategoryList)

    def test_article_detail_url_resolves_home_view(self):
        view = resolve('/articles/2022/01/01/name/')
        self.assertEquals(view.func.view_class, ArticleDetail)

    def test_category_view_status_code(self):
        url = reverse('articles-category-list', args=('name',))
        response = self.client.get(url)
        self.assertEquals(response.status_code, 200)

    def test_articles_view_status_code(self):
        url = reverse('articles-list')
        response = self.client.get(url)
        self.assertEquals(response.status_code, 200)

    def test_article_detail_view_status_code(self):
        date_now = datetime.date.today() + datetime.timedelta(500)
        url = reverse('news-detail', args=(date_now.strftime("%Y"), date_now.strftime("%m"),
                                           date_now.strftime("%d"), 'name'))
        response = self.client.get(url)
        self.assertEquals(response.status_code, 404)
