# Tolkien API

**The Tolkien API for Middle-Earth lovers.**

Docs: [tolkien-api.herokuapp.com](https://tolkien-api.herokuapp.com)

I created this Tolkien API to practice C#. The data is from the site [lotr.fandom.com](https://lotr.fandom.com), which also has its own open [API](https://lotr.wikia.com/api.php).

If you have an idea to add some more functionality, feel free to open the feature request.

## TODO

`in` and `by` endpoints would be more RESTful if they were query string params instead of separate endpoint. i.e. Instead of:

```
/battles/in/mordor
```

You'd do

```
/battles?location=mordor
```

Generally speaking, any filtering of result data should be done through query string params on GET requests.
