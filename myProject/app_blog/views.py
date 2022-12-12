from django.views.generic import DateDetailView, ListView

from .models import Article, Category


class HomePageView(ListView):
    model = Article
    template_name = 'index.html'
    context_object_name = 'categories'
    queryset = Category.objects.all()

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context["articles"] = Article.objects.filter(main_page=True)[:5]

        return context


class ArticleDetail(DateDetailView):
    model = Article
    template_name = 'article_detail.html'
    context_object_name = 'item'
    date_field = 'pub_date'
    query_pk_and_slug = True
    month_format = "%m"
    allow_future = True

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        try:
            context['image'] = context['item'].images.all()
        except:
            pass

        return context


class ArticleList(ListView):
    model = Article
    queryset = Article.objects.all()
    template_name = 'articles_list.html'
    context_object_name = 'items'

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        try:
            context["category"] = Category.objects.get(slug=self.kwargs.get("slug"))
        except:
            context["category"] = None

        return context


class ArticleCategoryList(ArticleList):
    def get_queryset(self):
        return super().get_queryset().filter(category__slug__in=[self.kwargs.get("slug")]).distinct()
