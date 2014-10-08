using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonMarker.Tests
{
    [TestClass]
    public class Spec
    {
        private void TestExample(string input, string expected)
        {

            var target = new Md2Html();
            var actual = target.Convert(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example1()
        {
            const string input = @"	foo	baz		bim";
            const string expected = @"<pre><code>foo baz     bim
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example2()
        {
            const string input = @"    a	a
    ὐ	a";
            const string expected = @"<pre><code>a   a
ὐ   a
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example3()
        {
            const string input = @"- `one
- two`";
            const string expected = @"<ul>
<li>`one</li>
<li>two`</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example4()
        {
            const string input = @"***
---
___";
            const string expected = @"<hr />
<hr />
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example5()
        {
            const string input = @"+++";
            const string expected = @"<p>+++</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example6()
        {
            const string input = @"===";
            const string expected = @"<p>===</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example7()
        {
            const string input = @"--
**
__";
            const string expected = @"<p>--
**
__</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example8()
        {
            const string input = @" ***
  ***
   ***";
            const string expected = @"<hr />
<hr />
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example9()
        {
            const string input = @"    ***";
            const string expected = @"<pre><code>***
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example10()
        {
            const string input = @"Foo
    ***";
            const string expected = @"<p>Foo
***</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example11()
        {
            const string input = @"_____________________________________";
            const string expected = @"<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example12()
        {
            const string input = @" - - -";
            const string expected = @"<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example13()
        {
            const string input = @" **  * ** * ** * **";
            const string expected = @"<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example14()
        {
            const string input = @"-     -      -      -";
            const string expected = @"<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example15()
        {
            const string input = @"- - - -    ";
            const string expected = @"<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example16()
        {
            const string input = @"_ _ _ _ a

a------";
            const string expected = @"<p>_ _ _ _ a</p>
<p>a------</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example17()
        {
            const string input = @" *-*";
            const string expected = @"<p><em>-</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example18()
        {
            const string input = @"- foo
***
- bar";
            const string expected = @"<ul>
<li>foo</li>
</ul>
<hr />
<ul>
<li>bar</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example19()
        {
            const string input = @"Foo
***
bar";
            const string expected = @"<p>Foo</p>
<hr />
<p>bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example20()
        {
            const string input = @"Foo
---
bar";
            const string expected = @"<h2>Foo</h2>
<p>bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example21()
        {
            const string input = @"* Foo
* * *
* Bar";
            const string expected = @"<ul>
<li>Foo</li>
</ul>
<hr />
<ul>
<li>Bar</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example22()
        {
            const string input = @"- Foo
- * * *";
            const string expected = @"<ul>
<li>Foo</li>
<li><hr /></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example23()
        {
            const string input = @"# foo
## foo
### foo
#### foo
##### foo
###### foo";
            const string expected = @"<h1>foo</h1>
<h2>foo</h2>
<h3>foo</h3>
<h4>foo</h4>
<h5>foo</h5>
<h6>foo</h6>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example24()
        {
            const string input = @"####### foo";
            const string expected = @"<p>####### foo</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example25()
        {
            const string input = @"#5 bolt";
            const string expected = @"<p>#5 bolt</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example26()
        {
            const string input = @"\## foo";
            const string expected = @"<p>## foo</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example27()
        {
            const string input = @"# foo *bar* \*baz\*";
            const string expected = @"<h1>foo <em>bar</em> *baz*</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example28()
        {
            const string input = @"#                  foo                     ";
            const string expected = @"<h1>foo</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example29()
        {
            const string input = @" ### foo
  ## foo
   # foo";
            const string expected = @"<h3>foo</h3>
<h2>foo</h2>
<h1>foo</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example30()
        {
            const string input = @"    # foo";
            const string expected = @"<pre><code># foo
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example31()
        {
            const string input = @"foo
    # bar";
            const string expected = @"<p>foo
# bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example32()
        {
            const string input = @"## foo ##
  ###   bar    ###";
            const string expected = @"<h2>foo</h2>
<h3>bar</h3>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example33()
        {
            const string input = @"# foo ##################################
##### foo ##";
            const string expected = @"<h1>foo</h1>
<h5>foo</h5>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example34()
        {
            const string input = @"### foo ###     ";
            const string expected = @"<h3>foo</h3>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example35()
        {
            const string input = @"### foo ### b";
            const string expected = @"<h3>foo ### b</h3>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example36()
        {
            const string input = @"### foo \###
## foo \#\##
# foo \#";
            const string expected = @"<h3>foo #</h3>
<h2>foo ##</h2>
<h1>foo #</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example37()
        {
            const string input = @"****
## foo
****";
            const string expected = @"<hr />
<h2>foo</h2>
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example38()
        {
            const string input = @"Foo bar
# baz
Bar foo";
            const string expected = @"<p>Foo bar</p>
<h1>baz</h1>
<p>Bar foo</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example39()
        {
            const string input = @"## 
#
### ###";
            const string expected = @"<h2></h2>
<h1></h1>
<h3></h3>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example40()
        {
            const string input = @"Foo *bar*
=========

Foo *bar*
---------";
            const string expected = @"<h1>Foo <em>bar</em></h1>
<h2>Foo <em>bar</em></h2>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example41()
        {
            const string input = @"Foo
-------------------------

Foo
=";
            const string expected = @"<h2>Foo</h2>
<h1>Foo</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example42()
        {
            const string input = @"   Foo
---

  Foo
-----

  Foo
  ===";
            const string expected = @"<h2>Foo</h2>
<h2>Foo</h2>
<h1>Foo</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example43()
        {
            const string input = @"    Foo
    ---

    Foo
---";
            const string expected = @"<pre><code>Foo
---

Foo
</code></pre>
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example44()
        {
            const string input = @"Foo
   ----      ";
            const string expected = @"<h2>Foo</h2>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example45()
        {
            const string input = @"Foo
     ---";
            const string expected = @"<p>Foo
---</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example46()
        {
            const string input = @"Foo
= =

Foo
--- -";
            const string expected = @"<p>Foo
= =</p>
<p>Foo</p>
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example47()
        {
            const string input = @"Foo  
-----";
            const string expected = @"<h2>Foo</h2>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example48()
        {
            const string input = @"Foo\
----";
            const string expected = @"<h2>Foo\</h2>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example49()
        {
            const string input = @"`Foo
----
`

&lt;a title=&quot;a lot
---
of dashes&quot;/&gt;";
            const string expected = @"<h2>`Foo</h2>
<p>`</p>
<h2>&lt;a title=&quot;a lot</h2>
<p>of dashes&quot;/&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example50()
        {
            const string input = @"&gt; Foo
---";
            const string expected = @"<blockquote>
<p>Foo</p>
</blockquote>
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example51()
        {
            const string input = @"Foo
Bar
---

Foo
Bar
===";
            const string expected = @"<p>Foo
Bar</p>
<hr />
<p>Foo
Bar
===</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example52()
        {
            const string input = @"---
Foo
---
Bar
---
Baz";
            const string expected = @"<hr />
<h2>Foo</h2>
<h2>Bar</h2>
<p>Baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example53()
        {
            const string input = @"
====";
            const string expected = @"<p>====</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example54()
        {
            const string input = @"    a simple
      indented code block";
            const string expected = @"<pre><code>a simple
  indented code block
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example55()
        {
            const string input = @"    &lt;a/&gt;
    *hi*

    - one";
            const string expected = @"<pre><code>&lt;a/&gt;
*hi*

- one
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example56()
        {
            const string input = @"    chunk1

    chunk2
  
 
 
    chunk3";
            const string expected = @"<pre><code>chunk1

chunk2



chunk3
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example57()
        {
            const string input = @"    chunk1
      
      chunk2";
            const string expected = @"<pre><code>chunk1
  
  chunk2
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example58()
        {
            const string input = @"Foo
    bar
";
            const string expected = @"<p>Foo
bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example59()
        {
            const string input = @"    foo
bar";
            const string expected = @"<pre><code>foo
</code></pre>
<p>bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example60()
        {
            const string input = @"# Header
    foo
Header
------
    foo
----";
            const string expected = @"<h1>Header</h1>
<pre><code>foo
</code></pre>
<h2>Header</h2>
<pre><code>foo
</code></pre>
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example61()
        {
            const string input = @"        foo
    bar";
            const string expected = @"<pre><code>    foo
bar
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example62()
        {
            const string input = @"
    
    foo
    
";
            const string expected = @"<pre><code>foo
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example63()
        {
            const string input = @"    foo  ";
            const string expected = @"<pre><code>foo  
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example64()
        {
            const string input = @"```
&lt;
 &gt;
```";
            const string expected = @"<pre><code>&lt;
 &gt;
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example65()
        {
            const string input = @"~~~
&lt;
 &gt;
~~~";
            const string expected = @"<pre><code>&lt;
 &gt;
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example66()
        {
            const string input = @"```
aaa
~~~
```";
            const string expected = @"<pre><code>aaa
~~~
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example67()
        {
            const string input = @"~~~
aaa
```
~~~";
            const string expected = @"<pre><code>aaa
```
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example68()
        {
            const string input = @"````
aaa
```
``````";
            const string expected = @"<pre><code>aaa
```
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example69()
        {
            const string input = @"~~~~
aaa
~~~
~~~~";
            const string expected = @"<pre><code>aaa
~~~
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example70()
        {
            const string input = @"```";
            const string expected = @"<pre><code></code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example71()
        {
            const string input = @"`````

```
aaa";
            const string expected = @"<pre><code>
```
aaa
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example72()
        {
            const string input = @"```

  
```";
            const string expected = @"<pre><code>
  
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example73()
        {
            const string input = @"```
```";
            const string expected = @"<pre><code></code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example74()
        {
            const string input = @" ```
 aaa
aaa
```";
            const string expected = @"<pre><code>aaa
aaa
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example75()
        {
            const string input = @"  ```
aaa
  aaa
aaa
  ```";
            const string expected = @"<pre><code>aaa
aaa
aaa
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example76()
        {
            const string input = @"   ```
   aaa
    aaa
  aaa
   ```";
            const string expected = @"<pre><code>aaa
 aaa
aaa
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example77()
        {
            const string input = @"    ```
    aaa
    ```";
            const string expected = @"<pre><code>```
aaa
```
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example78()
        {
            const string input = @"``` ```
aaa";
            const string expected = @"<p><code></code>
aaa</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example79()
        {
            const string input = @"~~~~~~
aaa
~~~ ~~";
            const string expected = @"<pre><code>aaa
~~~ ~~
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example80()
        {
            const string input = @"foo
```
bar
```
baz";
            const string expected = @"<p>foo</p>
<pre><code>bar
</code></pre>
<p>baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example81()
        {
            const string input = @"foo
---
~~~
bar
~~~
# baz";
            const string expected = @"<h2>foo</h2>
<pre><code>bar
</code></pre>
<h1>baz</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example82()
        {
            const string input = @"```ruby
def foo(x)
  return 3
end
```";
            const string expected = @"<pre><code class=""language-ruby"">def foo(x)
  return 3
end
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example83()
        {
            const string input = @"~~~~    ruby startline=3 $%@#$
def foo(x)
  return 3
end
~~~~~~~";
            const string expected = @"<pre><code class=""language-ruby"">def foo(x)
  return 3
end
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example84()
        {
            const string input = @"````;
````";
            const string expected = @"<pre><code class=""language-;""></code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example85()
        {
            const string input = @"``` aa ```
foo";
            const string expected = @"<p><code>aa</code>
foo</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example86()
        {
            const string input = @"```
``` aaa
```";
            const string expected = @"<pre><code>``` aaa
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example87()
        {
            const string input = @"&lt;table&gt;
  &lt;tr&gt;
    &lt;td&gt;
           hi
    &lt;/td&gt;
  &lt;/tr&gt;
&lt;/table&gt;

okay.";
            const string expected = @"<table>
  <tr>
    <td>
           hi
    </td>
  </tr>
</table>
<p>okay.</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example88()
        {
            const string input = @" &lt;div&gt;
  *hello*
         &lt;foo&gt;&lt;a&gt;";
            const string expected = @" <div>
  *hello*
         <foo><a>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example89()
        {
            const string input = @"&lt;DIV CLASS=&quot;foo&quot;&gt;

*Markdown*

&lt;/DIV&gt;";
            const string expected = @"<DIV CLASS=""foo"">
<p><em>Markdown</em></p>
</DIV>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example90()
        {
            const string input = @"&lt;div&gt;&lt;/div&gt;
``` c
int x = 33;
```";
            const string expected = @"<div></div>
``` c
int x = 33;
```";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example91()
        {
            const string input = @"&lt;!-- Foo
bar
   baz --&gt;";
            const string expected = @"<!-- Foo
bar
   baz -->";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example92()
        {
            const string input = @"&lt;?php
  echo &#39;foo&#39;
?&gt;";
            const string expected = @"<?php
  echo 'foo'
?>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example93()
        {
            const string input = @"&lt;![CDATA[
function matchwo(a,b)
{
if (a &lt; b &amp;&amp; a &lt; 0) then
  {
  return 1;
  }
else
  {
  return 0;
  }
}
]]&gt;";
            const string expected = @"<![CDATA[
function matchwo(a,b)
{
if (a < b && a < 0) then
  {
  return 1;
  }
else
  {
  return 0;
  }
}
]]>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example94()
        {
            const string input = @"  &lt;!-- foo --&gt;

    &lt;!-- foo --&gt;";
            const string expected = @"  <!-- foo -->
<pre><code>&lt;!-- foo --&gt;
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example95()
        {
            const string input = @"Foo
&lt;div&gt;
bar
&lt;/div&gt;";
            const string expected = @"<p>Foo</p>
<div>
bar
</div>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example96()
        {
            const string input = @"&lt;div&gt;
bar
&lt;/div&gt;
*foo*";
            const string expected = @"<div>
bar
</div>
*foo*";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example97()
        {
            const string input = @"&lt;div class
foo";
            const string expected = @"<div class
foo";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example98()
        {
            const string input = @"&lt;div&gt;

*Emphasized* text.

&lt;/div&gt;";
            const string expected = @"<div>
<p><em>Emphasized</em> text.</p>
</div>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example99()
        {
            const string input = @"&lt;div&gt;
*Emphasized* text.
&lt;/div&gt;";
            const string expected = @"<div>
*Emphasized* text.
</div>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example100()
        {
            const string input = @"&lt;table&gt;

&lt;tr&gt;

&lt;td&gt;
Hi
&lt;/td&gt;

&lt;/tr&gt;

&lt;/table&gt;";
            const string expected = @"<table>
<tr>
<td>
Hi
</td>
</tr>
</table>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example101()
        {
            const string input = @"[foo]: /url &quot;title&quot;

[foo]";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example102()
        {
            const string input = @"   [foo]: 
      /url  
           &#39;the title&#39;  

[foo]";
            const string expected = @"<p><a href=""/url"" title=""the title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example103()
        {
            const string input = @"[Foo*bar\]]:my_(url) &#39;title (with parens)&#39;

[Foo*bar\]]";
            const string expected = @"<p><a href=""my_(url)"" title=""title (with parens)"">Foo*bar]</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example104()
        {
            const string input = @"[Foo bar]:
&lt;my url&gt;
&#39;title&#39;

[Foo bar]";
            const string expected = @"<p><a href=""my%20url"" title=""title"">Foo bar</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example105()
        {
            const string input = @"[foo]:
/url

[foo]";
            const string expected = @"<p><a href=""/url"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example106()
        {
            const string input = @"[foo]:

[foo]";
            const string expected = @"<p>[foo]:</p>
<p>[foo]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example107()
        {
            const string input = @"[foo]

[foo]: url";
            const string expected = @"<p><a href=""url"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example108()
        {
            const string input = @"[foo]

[foo]: first
[foo]: second";
            const string expected = @"<p><a href=""first"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example109()
        {
            const string input = @"[FOO]: /url

[Foo]";
            const string expected = @"<p><a href=""/url"">Foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example110()
        {
            const string input = @"[ΑΓΩ]: /φου

[αγω]";
            const string expected = @"<p><a href=""/%CF%86%CE%BF%CF%85"">αγω</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example111()
        {
            const string input = @"[foo]: /url";
            const string expected = @"";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example112()
        {
            const string input = @"[foo]: /url &quot;title&quot; ok";
            const string expected = @"<p>[foo]: /url &quot;title&quot; ok</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example113()
        {
            const string input = @"    [foo]: /url &quot;title&quot;

[foo]";
            const string expected = @"<pre><code>[foo]: /url &quot;title&quot;
</code></pre>
<p>[foo]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example114()
        {
            const string input = @"```
[foo]: /url
```

[foo]";
            const string expected = @"<pre><code>[foo]: /url
</code></pre>
<p>[foo]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example115()
        {
            const string input = @"Foo
[bar]: /baz

[bar]";
            const string expected = @"<p>Foo
[bar]: /baz</p>
<p>[bar]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example116()
        {
            const string input = @"# [Foo]
[foo]: /url
&gt; bar";
            const string expected = @"<h1><a href=""/url"">Foo</a></h1>
<blockquote>
<p>bar</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example117()
        {
            const string input = @"[foo]: /foo-url &quot;foo&quot;
[bar]: /bar-url
  &quot;bar&quot;
[baz]: /baz-url

[foo],
[bar],
[baz]";
            const string expected = @"<p><a href=""/foo-url"" title=""foo"">foo</a>,
<a href=""/bar-url"" title=""bar"">bar</a>,
<a href=""/baz-url"">baz</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example118()
        {
            const string input = @"[foo]

&gt; [foo]: /url";
            const string expected = @"<p><a href=""/url"">foo</a></p>
<blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example119()
        {
            const string input = @"aaa

bbb";
            const string expected = @"<p>aaa</p>
<p>bbb</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example120()
        {
            const string input = @"aaa
bbb

ccc
ddd";
            const string expected = @"<p>aaa
bbb</p>
<p>ccc
ddd</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example121()
        {
            const string input = @"aaa


bbb";
            const string expected = @"<p>aaa</p>
<p>bbb</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example122()
        {
            const string input = @"  aaa
 bbb";
            const string expected = @"<p>aaa
bbb</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example123()
        {
            const string input = @"aaa
             bbb
                                       ccc";
            const string expected = @"<p>aaa
bbb
ccc</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example124()
        {
            const string input = @"   aaa
bbb";
            const string expected = @"<p>aaa
bbb</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example125()
        {
            const string input = @"    aaa
bbb";
            const string expected = @"<pre><code>aaa
</code></pre>
<p>bbb</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example126()
        {
            const string input = @"aaa     
bbb     ";
            const string expected = @"<p>aaa<br />
bbb</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example127()
        {
            const string input = @"  

aaa
  

# aaa

  ";
            const string expected = @"<p>aaa</p>
<h1>aaa</h1>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example128()
        {
            const string input = @"&gt; # Foo
&gt; bar
&gt; baz";
            const string expected = @"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example129()
        {
            const string input = @"&gt;# Foo
&gt;bar
&gt; baz";
            const string expected = @"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example130()
        {
            const string input = @"   &gt; # Foo
   &gt; bar
 &gt; baz";
            const string expected = @"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example131()
        {
            const string input = @"    &gt; # Foo
    &gt; bar
    &gt; baz";
            const string expected = @"<pre><code>&gt; # Foo
&gt; bar
&gt; baz
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example132()
        {
            const string input = @"&gt; # Foo
&gt; bar
baz";
            const string expected = @"<blockquote>
<h1>Foo</h1>
<p>bar
baz</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example133()
        {
            const string input = @"&gt; bar
baz
&gt; foo";
            const string expected = @"<blockquote>
<p>bar
baz
foo</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example134()
        {
            const string input = @"&gt; foo
---";
            const string expected = @"<blockquote>
<p>foo</p>
</blockquote>
<hr />";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example135()
        {
            const string input = @"&gt; - foo
- bar";
            const string expected = @"<blockquote>
<ul>
<li>foo</li>
</ul>
</blockquote>
<ul>
<li>bar</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example136()
        {
            const string input = @"&gt;     foo
    bar";
            const string expected = @"<blockquote>
<pre><code>foo
</code></pre>
</blockquote>
<pre><code>bar
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example137()
        {
            const string input = @"&gt; ```
foo
```";
            const string expected = @"<blockquote>
<pre><code></code></pre>
</blockquote>
<p>foo</p>
<pre><code></code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example138()
        {
            const string input = @"&gt;";
            const string expected = @"<blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example139()
        {
            const string input = @"&gt;
&gt;  
&gt; ";
            const string expected = @"<blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example140()
        {
            const string input = @"&gt;
&gt; foo
&gt;  ";
            const string expected = @"<blockquote>
<p>foo</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example141()
        {
            const string input = @"&gt; foo

&gt; bar";
            const string expected = @"<blockquote>
<p>foo</p>
</blockquote>
<blockquote>
<p>bar</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example142()
        {
            const string input = @"&gt; foo
&gt; bar";
            const string expected = @"<blockquote>
<p>foo
bar</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example143()
        {
            const string input = @"&gt; foo
&gt;
&gt; bar";
            const string expected = @"<blockquote>
<p>foo</p>
<p>bar</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example144()
        {
            const string input = @"foo
&gt; bar";
            const string expected = @"<p>foo</p>
<blockquote>
<p>bar</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example145()
        {
            const string input = @"&gt; aaa
***
&gt; bbb";
            const string expected = @"<blockquote>
<p>aaa</p>
</blockquote>
<hr />
<blockquote>
<p>bbb</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example146()
        {
            const string input = @"&gt; bar
baz";
            const string expected = @"<blockquote>
<p>bar
baz</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example147()
        {
            const string input = @"&gt; bar

baz";
            const string expected = @"<blockquote>
<p>bar</p>
</blockquote>
<p>baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example148()
        {
            const string input = @"&gt; bar
&gt;
baz";
            const string expected = @"<blockquote>
<p>bar</p>
</blockquote>
<p>baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example149()
        {
            const string input = @"&gt; &gt; &gt; foo
bar";
            const string expected = @"<blockquote>
<blockquote>
<blockquote>
<p>foo
bar</p>
</blockquote>
</blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example150()
        {
            const string input = @"&gt;&gt;&gt; foo
&gt; bar
&gt;&gt;baz";
            const string expected = @"<blockquote>
<blockquote>
<blockquote>
<p>foo
bar
baz</p>
</blockquote>
</blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example151()
        {
            const string input = @"&gt;     code

&gt;    not code";
            const string expected = @"<blockquote>
<pre><code>code
</code></pre>
</blockquote>
<blockquote>
<p>not code</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example152()
        {
            const string input = @"A paragraph
with two lines.

    indented code

&gt; A block quote.";
            const string expected = @"<p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example153()
        {
            const string input = @"1.  A paragraph
    with two lines.

        indented code

    &gt; A block quote.";
            const string expected = @"<ol>
<li><p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example154()
        {
            const string input = @"- one

 two";
            const string expected = @"<ul>
<li>one</li>
</ul>
<p>two</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example155()
        {
            const string input = @"- one

  two";
            const string expected = @"<ul>
<li><p>one</p>
<p>two</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example156()
        {
            const string input = @" -    one

     two";
            const string expected = @"<ul>
<li>one</li>
</ul>
<pre><code> two
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example157()
        {
            const string input = @" -    one

      two";
            const string expected = @"<ul>
<li><p>one</p>
<p>two</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example158()
        {
            const string input = @"   &gt; &gt; 1.  one
&gt;&gt;
&gt;&gt;     two";
            const string expected = @"<blockquote>
<blockquote>
<ol>
<li><p>one</p>
<p>two</p></li>
</ol>
</blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example159()
        {
            const string input = @"&gt;&gt;- one
&gt;&gt;
  &gt;  &gt; two";
            const string expected = @"<blockquote>
<blockquote>
<ul>
<li>one</li>
</ul>
<p>two</p>
</blockquote>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example160()
        {
            const string input = @"- foo

  bar

- foo


  bar

- ```
  foo


  bar
  ```";
            const string expected = @"<ul>
<li><p>foo</p>
<p>bar</p></li>
<li><p>foo</p></li>
</ul>
<p>bar</p>
<ul>
<li><pre><code>foo


bar
</code></pre></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example161()
        {
            const string input = @"1.  foo

    ```
    bar
    ```

    baz

    &gt; bam";
            const string expected = @"<ol>
<li><p>foo</p>
<pre><code>bar
</code></pre>
<p>baz</p>
<blockquote>
<p>bam</p>
</blockquote></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example162()
        {
            const string input = @"- foo

      bar";
            const string expected = @"<ul>
<li><p>foo</p>
<pre><code>bar
</code></pre></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example163()
        {
            const string input = @"  10.  foo

           bar";
            const string expected = @"<ol start=""10"">
<li><p>foo</p>
<pre><code>bar
</code></pre></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example164()
        {
            const string input = @"    indented code

paragraph

    more code";
            const string expected = @"<pre><code>indented code
</code></pre>
<p>paragraph</p>
<pre><code>more code
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example165()
        {
            const string input = @"1.     indented code

   paragraph

       more code";
            const string expected = @"<ol>
<li><pre><code>indented code
</code></pre>
<p>paragraph</p>
<pre><code>more code
</code></pre></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example166()
        {
            const string input = @"1.      indented code

   paragraph

       more code";
            const string expected = @"<ol>
<li><pre><code> indented code
</code></pre>
<p>paragraph</p>
<pre><code>more code
</code></pre></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example167()
        {
            const string input = @"   foo

bar";
            const string expected = @"<p>foo</p>
<p>bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example168()
        {
            const string input = @"-    foo

  bar";
            const string expected = @"<ul>
<li>foo</li>
</ul>
<p>bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example169()
        {
            const string input = @"-  foo

   bar";
            const string expected = @"<ul>
<li><p>foo</p>
<p>bar</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example170()
        {
            const string input = @" 1.  A paragraph
     with two lines.

         indented code

     &gt; A block quote.";
            const string expected = @"<ol>
<li><p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example171()
        {
            const string input = @"  1.  A paragraph
      with two lines.

          indented code

      &gt; A block quote.";
            const string expected = @"<ol>
<li><p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example172()
        {
            const string input = @"   1.  A paragraph
       with two lines.

           indented code

       &gt; A block quote.";
            const string expected = @"<ol>
<li><p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example173()
        {
            const string input = @"    1.  A paragraph
        with two lines.

            indented code

        &gt; A block quote.";
            const string expected = @"<pre><code>1.  A paragraph
    with two lines.

        indented code

    &gt; A block quote.
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example174()
        {
            const string input = @"  1.  A paragraph
with two lines.

          indented code

      &gt; A block quote.";
            const string expected = @"<ol>
<li><p>A paragraph
with two lines.</p>
<pre><code>indented code
</code></pre>
<blockquote>
<p>A block quote.</p>
</blockquote></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example175()
        {
            const string input = @"  1.  A paragraph
    with two lines.";
            const string expected = @"<ol>
<li>A paragraph
with two lines.</li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example176()
        {
            const string input = @"&gt; 1. &gt; Blockquote
continued here.";
            const string expected = @"<blockquote>
<ol>
<li><blockquote>
<p>Blockquote
continued here.</p>
</blockquote></li>
</ol>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example177()
        {
            const string input = @"&gt; 1. &gt; Blockquote
&gt; continued here.";
            const string expected = @"<blockquote>
<ol>
<li><blockquote>
<p>Blockquote
continued here.</p>
</blockquote></li>
</ol>
</blockquote>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example178()
        {
            const string input = @"- foo
  - bar
    - baz";
            const string expected = @"<ul>
<li>foo
<ul>
<li>bar
<ul>
<li>baz</li>
</ul></li>
</ul></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example179()
        {
            const string input = @"- foo
 - bar
  - baz";
            const string expected = @"<ul>
<li>foo</li>
<li>bar</li>
<li>baz</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example180()
        {
            const string input = @"10) foo
    - bar";
            const string expected = @"<ol start=""10"">
<li>foo
<ul>
<li>bar</li>
</ul></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example181()
        {
            const string input = @"10) foo
   - bar";
            const string expected = @"<ol start=""10"">
<li>foo</li>
</ol>
<ul>
<li>bar</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example182()
        {
            const string input = @"- - foo";
            const string expected = @"<ul>
<li><ul>
<li>foo</li>
</ul></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example183()
        {
            const string input = @"1. - 2. foo";
            const string expected = @"<ol>
<li><ul>
<li><ol start=""2"">
<li>foo</li>
</ol></li>
</ul></li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example184()
        {
            const string input = @"- foo
-
- bar";
            const string expected = @"<ul>
<li>foo</li>
<li></li>
<li>bar</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example185()
        {
            const string input = @"-";
            const string expected = @"<ul>
<li></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example186()
        {
            const string input = @"- foo
- bar
+ baz";
            const string expected = @"<ul>
<li>foo</li>
<li>bar</li>
</ul>
<ul>
<li>baz</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example187()
        {
            const string input = @"1. foo
2. bar
3) baz";
            const string expected = @"<ol>
<li>foo</li>
<li>bar</li>
</ol>
<ol start=""3"">
<li>baz</li>
</ol>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example188()
        {
            const string input = @"- foo

- bar


- baz";
            const string expected = @"<ul>
<li><p>foo</p></li>
<li><p>bar</p></li>
</ul>
<ul>
<li>baz</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example189()
        {
            const string input = @"- foo


  bar
- baz";
            const string expected = @"<ul>
<li>foo</li>
</ul>
<p>bar</p>
<ul>
<li>baz</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example190()
        {
            const string input = @"- foo
  - bar
    - baz


      bim";
            const string expected = @"<ul>
<li>foo
<ul>
<li>bar
<ul>
<li>baz</li>
</ul></li>
</ul></li>
</ul>
<pre><code>  bim
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example191()
        {
            const string input = @"- foo
- bar


- baz
- bim";
            const string expected = @"<ul>
<li>foo</li>
<li>bar</li>
</ul>
<ul>
<li>baz</li>
<li>bim</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example192()
        {
            const string input = @"-   foo

    notcode

-   foo


    code";
            const string expected = @"<ul>
<li><p>foo</p>
<p>notcode</p></li>
<li><p>foo</p></li>
</ul>
<pre><code>code
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example193()
        {
            const string input = @"- a
 - b
  - c
   - d
  - e
 - f
- g";
            const string expected = @"<ul>
<li>a</li>
<li>b</li>
<li>c</li>
<li>d</li>
<li>e</li>
<li>f</li>
<li>g</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example194()
        {
            const string input = @"- a
- b

- c";
            const string expected = @"<ul>
<li><p>a</p></li>
<li><p>b</p></li>
<li><p>c</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example195()
        {
            const string input = @"* a
*

* c";
            const string expected = @"<ul>
<li><p>a</p></li>
<li></li>
<li><p>c</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example196()
        {
            const string input = @"- a
- b

  c
- d";
            const string expected = @"<ul>
<li><p>a</p></li>
<li><p>b</p>
<p>c</p></li>
<li><p>d</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example197()
        {
            const string input = @"- a
- b

  [ref]: /url
- d";
            const string expected = @"<ul>
<li><p>a</p></li>
<li><p>b</p></li>
<li><p>d</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example198()
        {
            const string input = @"- a
- ```
  b


  ```
- c";
            const string expected = @"<ul>
<li>a</li>
<li><pre><code>b


</code></pre></li>
<li>c</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example199()
        {
            const string input = @"- a
  - b

    c
- d";
            const string expected = @"<ul>
<li>a
<ul>
<li><p>b</p>
<p>c</p></li>
</ul></li>
<li>d</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example200()
        {
            const string input = @"* a
  &gt; b
  &gt;
* c";
            const string expected = @"<ul>
<li>a
<blockquote>
<p>b</p>
</blockquote></li>
<li>c</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example201()
        {
            const string input = @"- a
  &gt; b
  ```
  c
  ```
- d";
            const string expected = @"<ul>
<li>a
<blockquote>
<p>b</p>
</blockquote>
<pre><code>c
</code></pre></li>
<li>d</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example202()
        {
            const string input = @"- a";
            const string expected = @"<ul>
<li>a</li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example203()
        {
            const string input = @"- a
  - b";
            const string expected = @"<ul>
<li>a
<ul>
<li>b</li>
</ul></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example204()
        {
            const string input = @"* foo
  * bar

  baz";
            const string expected = @"<ul>
<li><p>foo</p>
<ul>
<li>bar</li>
</ul>
<p>baz</p></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example205()
        {
            const string input = @"- a
  - b
  - c

- d
  - e
  - f";
            const string expected = @"<ul>
<li><p>a</p>
<ul>
<li>b</li>
<li>c</li>
</ul></li>
<li><p>d</p>
<ul>
<li>e</li>
<li>f</li>
</ul></li>
</ul>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example206()
        {
            const string input = @"`hi`lo`";
            const string expected = @"<p><code>hi</code>lo`</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example207()
        {
            const string input = @"\!\&quot;\#\$\%\&amp;\&#39;\(\)\*\+\,\-\.\/\:\;\&lt;\=\&gt;\?\@\[\\\]\^\_\`\{\|\}\~";
            const string expected = @"<p>!&quot;#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example208()
        {
            const string input = @"\	\A\a\ \3\φ\«";
            const string expected = @"<p>\   \A\a\ \3\φ\«</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example209()
        {
            const string input = @"\*not emphasized*
\&lt;br/&gt; not a tag
\[not a link](/foo)
\`not code`
1\. not a list
\* not a list
\# not a header
\[foo]: /url &quot;not a reference&quot;";
            const string expected = @"<p>*not emphasized*
&lt;br/&gt; not a tag
[not a link](/foo)
`not code`
1. not a list
* not a list
# not a header
[foo]: /url &quot;not a reference&quot;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example210()
        {
            const string input = @"\\*emphasis*";
            const string expected = @"<p>\<em>emphasis</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example211()
        {
            const string input = @"foo\
bar";
            const string expected = @"<p>foo<br />
bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example212()
        {
            const string input = @"`` \[\` ``";
            const string expected = @"<p><code>\[\`</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example213()
        {
            const string input = @"    \[\]";
            const string expected = @"<pre><code>\[\]
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example214()
        {
            const string input = @"~~~
\[\]
~~~";
            const string expected = @"<pre><code>\[\]
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example215()
        {
            const string input = @"&lt;http://google.com?find=\*&gt;";
            const string expected = @"<p><a href=""http://google.com?find=%5C*"">http://google.com?find=\*</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example216()
        {
            const string input = @"&lt;a href=&quot;/bar\/)&quot;&gt;";
            const string expected = @"<p><a href=""/bar\/)""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example217()
        {
            const string input = @"[foo](/bar\* &quot;ti\*tle&quot;)";
            const string expected = @"<p><a href=""/bar*"" title=""ti*tle"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example218()
        {
            const string input = @"[foo]

[foo]: /bar\* &quot;ti\*tle&quot;";
            const string expected = @"<p><a href=""/bar*"" title=""ti*tle"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example219()
        {
            const string input = @"``` foo\+bar
foo
```";
            const string expected = @"<pre><code class=""language-foo+bar"">foo
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example220()
        {
            const string input = @"&amp;nbsp; &amp;amp; &amp;copy; &amp;AElig; &amp;Dcaron; &amp;frac34; &amp;HilbertSpace; &amp;DifferentialD; &amp;ClockwiseContourIntegral;";
            const string expected = @"<p>  &amp; © Æ Ď ¾ ℋ ⅆ ∲</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example221()
        {
            const string input = @"&amp;#35; &amp;#1234; &amp;#992; &amp;#98765432;";
            const string expected = @"<p># Ӓ Ϡ �</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example222()
        {
            const string input = @"&amp;#X22; &amp;#XD06; &amp;#xcab;";
            const string expected = @"<p>&quot; ആ ಫ</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example223()
        {
            const string input = @"&amp;nbsp &amp;x; &amp;#; &amp;#x; &amp;ThisIsWayTooLongToBeAnEntityIsntIt; &amp;hi?;";
            const string expected = @"<p>&amp;nbsp &amp;x; &amp;#; &amp;#x; &amp;ThisIsWayTooLongToBeAnEntityIsntIt; &amp;hi?;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example224()
        {
            const string input = @"&amp;copy";
            const string expected = @"<p>&amp;copy</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example225()
        {
            const string input = @"&amp;MadeUpEntity;";
            const string expected = @"<p>&amp;MadeUpEntity;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example226()
        {
            const string input = @"&lt;a href=&quot;&amp;ouml;&amp;ouml;.html&quot;&gt;";
            const string expected = @"<p><a href=""&ouml;&ouml;.html""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example227()
        {
            const string input = @"[foo](/f&amp;ouml;&amp;ouml; &quot;f&amp;ouml;&amp;ouml;&quot;)";
            const string expected = @"<p><a href=""/f%C3%B6%C3%B6"" title=""föö"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example228()
        {
            const string input = @"[foo]

[foo]: /f&amp;ouml;&amp;ouml; &quot;f&amp;ouml;&amp;ouml;&quot;";
            const string expected = @"<p><a href=""/f%C3%B6%C3%B6"" title=""föö"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example229()
        {
            const string input = @"``` f&amp;ouml;&amp;ouml;
foo
```";
            const string expected = @"<pre><code class=""language-föö"">foo
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example230()
        {
            const string input = @"`f&amp;ouml;&amp;ouml;`";
            const string expected = @"<p><code>f&amp;ouml;&amp;ouml;</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example231()
        {
            const string input = @"    f&amp;ouml;f&amp;ouml;";
            const string expected = @"<pre><code>f&amp;ouml;f&amp;ouml;
</code></pre>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example232()
        {
            const string input = @"`foo`";
            const string expected = @"<p><code>foo</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example233()
        {
            const string input = @"`` foo ` bar  ``";
            const string expected = @"<p><code>foo ` bar</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example234()
        {
            const string input = @"` `` `";
            const string expected = @"<p><code>``</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example235()
        {
            const string input = @"``
foo
``";
            const string expected = @"<p><code>foo</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example236()
        {
            const string input = @"`foo   bar
  baz`";
            const string expected = @"<p><code>foo bar baz</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example237()
        {
            const string input = @"`foo `` bar`";
            const string expected = @"<p><code>foo `` bar</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example238()
        {
            const string input = @"`foo\`bar`";
            const string expected = @"<p><code>foo\</code>bar`</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example239()
        {
            const string input = @"*foo`*`";
            const string expected = @"<p>*foo<code>*</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example240()
        {
            const string input = @"[not a `link](/foo`)";
            const string expected = @"<p>[not a <code>link](/foo</code>)</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example241()
        {
            const string input = @"&lt;http://foo.bar.`baz&gt;`";
            const string expected = @"<p><a href=""http://foo.bar.%60baz"">http://foo.bar.`baz</a>`</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example242()
        {
            const string input = @"&lt;a href=&quot;`&quot;&gt;`";
            const string expected = @"<p><a href=""`"">`</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example243()
        {
            const string input = @"```foo``";
            const string expected = @"<p>```foo``</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example244()
        {
            const string input = @"`foo";
            const string expected = @"<p>`foo</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example245()
        {
            const string input = @"*foo bar*";
            const string expected = @"<p><em>foo bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example246()
        {
            const string input = @"_foo bar_";
            const string expected = @"<p><em>foo bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example247()
        {
            const string input = @"**foo bar**";
            const string expected = @"<p><strong>foo bar</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example248()
        {
            const string input = @"__foo bar__";
            const string expected = @"<p><strong>foo bar</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example249()
        {
            const string input = @"*foo
bar*";
            const string expected = @"<p><em>foo
bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example250()
        {
            const string input = @"_foo
bar_";
            const string expected = @"<p><em>foo
bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example251()
        {
            const string input = @"**foo
bar**";
            const string expected = @"<p><strong>foo
bar</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example252()
        {
            const string input = @"__foo
bar__";
            const string expected = @"<p><strong>foo
bar</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example253()
        {
            const string input = @"*foo [bar](/url)*";
            const string expected = @"<p><em>foo <a href=""/url"">bar</a></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example254()
        {
            const string input = @"_foo [bar](/url)_";
            const string expected = @"<p><em>foo <a href=""/url"">bar</a></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example255()
        {
            const string input = @"**foo [bar](/url)**";
            const string expected = @"<p><strong>foo <a href=""/url"">bar</a></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example256()
        {
            const string input = @"__foo [bar](/url)__";
            const string expected = @"<p><strong>foo <a href=""/url"">bar</a></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example257()
        {
            const string input = @"*foo [bar*](/url)";
            const string expected = @"<p>*foo <a href=""/url"">bar*</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example258()
        {
            const string input = @"_foo [bar_](/url)";
            const string expected = @"<p>_foo <a href=""/url"">bar_</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example259()
        {
            const string input = @"**&lt;a href=&quot;**&quot;&gt;";
            const string expected = @"<p>**<a href=""**""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example260()
        {
            const string input = @"__&lt;a href=&quot;__&quot;&gt;";
            const string expected = @"<p>__<a href=""__""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example261()
        {
            const string input = @"*a `*`*";
            const string expected = @"<p><em>a <code>*</code></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example262()
        {
            const string input = @"_a `_`_";
            const string expected = @"<p><em>a <code>_</code></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example263()
        {
            const string input = @"**a&lt;http://foo.bar?q=**&gt;";
            const string expected = @"<p>**a<a href=""http://foo.bar?q=**"">http://foo.bar?q=**</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example264()
        {
            const string input = @"__a&lt;http://foo.bar?q=__&gt;";
            const string expected = @"<p>__a<a href=""http://foo.bar?q=__"">http://foo.bar?q=__</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example265()
        {
            const string input = @"and * foo bar*";
            const string expected = @"<p>and * foo bar*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example266()
        {
            const string input = @"_ foo bar_";
            const string expected = @"<p>_ foo bar_</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example267()
        {
            const string input = @"and ** foo bar**";
            const string expected = @"<p>and ** foo bar**</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example268()
        {
            const string input = @"__ foo bar__";
            const string expected = @"<p>__ foo bar__</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example269()
        {
            const string input = @"and *foo bar *";
            const string expected = @"<p>and *foo bar *</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example270()
        {
            const string input = @"and _foo bar _";
            const string expected = @"<p>and _foo bar _</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example271()
        {
            const string input = @"and **foo bar **";
            const string expected = @"<p>and **foo bar **</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example272()
        {
            const string input = @"and __foo bar __";
            const string expected = @"<p>and __foo bar __</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example273()
        {
            const string input = @"****hi****";
            const string expected = @"<p>****hi****</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example274()
        {
            const string input = @"_____hi_____";
            const string expected = @"<p>_____hi_____</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example275()
        {
            const string input = @"Sign here: _________";
            const string expected = @"<p>Sign here: _________</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example276()
        {
            const string input = @"** is not an empty emphasis";
            const string expected = @"<p>** is not an empty emphasis</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example277()
        {
            const string input = @"**** is not an empty strong emphasis";
            const string expected = @"<p>**** is not an empty strong emphasis</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example278()
        {
            const string input = @"*here is a \**";
            const string expected = @"<p><em>here is a *</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example279()
        {
            const string input = @"__this is a double underscore (`__`)__";
            const string expected = @"<p><strong>this is a double underscore (<code>__</code>)</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example280()
        {
            const string input = @"foo*bar*baz";
            const string expected = @"<p>foo<em>bar</em>baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example281()
        {
            const string input = @"foo_bar_baz";
            const string expected = @"<p>foo_bar_baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example282()
        {
            const string input = @"foo__bar__baz";
            const string expected = @"<p>foo__bar__baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example283()
        {
            const string input = @"_foo_bar_baz_";
            const string expected = @"<p><em>foo_bar_baz</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example284()
        {
            const string input = @"11*15*32";
            const string expected = @"<p>11<em>15</em>32</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example285()
        {
            const string input = @"11_15_32";
            const string expected = @"<p>11_15_32</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example286()
        {
            const string input = @"_foo_bar_baz_";
            const string expected = @"<p><em>foo_bar_baz</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example287()
        {
            const string input = @"__foo__bar__baz__";
            const string expected = @"<p><strong>foo__bar__baz</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example288()
        {
            const string input = @"***foo bar***";
            const string expected = @"<p><strong><em>foo bar</em></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example289()
        {
            const string input = @"___foo bar___";
            const string expected = @"<p><strong><em>foo bar</em></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example290()
        {
            const string input = @"***foo** bar*";
            const string expected = @"<p><em><strong>foo</strong> bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example291()
        {
            const string input = @"___foo__ bar_";
            const string expected = @"<p><em><strong>foo</strong> bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example292()
        {
            const string input = @"***foo* bar**";
            const string expected = @"<p><strong><em>foo</em> bar</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example293()
        {
            const string input = @"___foo_ bar__";
            const string expected = @"<p><strong><em>foo</em> bar</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example294()
        {
            const string input = @"*foo **bar***";
            const string expected = @"<p><em>foo <strong>bar</strong></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example295()
        {
            const string input = @"_foo __bar___";
            const string expected = @"<p><em>foo <strong>bar</strong></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example296()
        {
            const string input = @"**foo *bar***";
            const string expected = @"<p><strong>foo <em>bar</em></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example297()
        {
            const string input = @"__foo _bar___";
            const string expected = @"<p><strong>foo <em>bar</em></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example298()
        {
            const string input = @"*foo **bar***";
            const string expected = @"<p><em>foo <strong>bar</strong></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example299()
        {
            const string input = @"_foo __bar___";
            const string expected = @"<p><em>foo <strong>bar</strong></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example300()
        {
            const string input = @"*foo *bar* baz*";
            const string expected = @"<p><em>foo <em>bar</em> baz</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example301()
        {
            const string input = @"_foo _bar_ baz_";
            const string expected = @"<p><em>foo <em>bar</em> baz</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example302()
        {
            const string input = @"**foo **bar** baz**";
            const string expected = @"<p><strong>foo <strong>bar</strong> baz</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example303()
        {
            const string input = @"__foo __bar__ baz__";
            const string expected = @"<p><strong>foo <strong>bar</strong> baz</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example304()
        {
            const string input = @"*foo **bar** baz*";
            const string expected = @"<p><em>foo <strong>bar</strong> baz</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example305()
        {
            const string input = @"_foo __bar__ baz_";
            const string expected = @"<p><em>foo <strong>bar</strong> baz</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example306()
        {
            const string input = @"**foo *bar* baz**";
            const string expected = @"<p><strong>foo <em>bar</em> baz</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example307()
        {
            const string input = @"__foo _bar_ baz__";
            const string expected = @"<p><strong>foo <em>bar</em> baz</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example308()
        {
            const string input = @"**foo**";
            const string expected = @"<p><strong>foo</strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example309()
        {
            const string input = @"****foo****";
            const string expected = @"<p>****foo****</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example310()
        {
            const string input = @"*_foo_*";
            const string expected = @"<p><em><em>foo</em></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example311()
        {
            const string input = @"**__foo__**";
            const string expected = @"<p><strong><strong>foo</strong></strong></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example312()
        {
            const string input = @"*foo**";
            const string expected = @"<p><em>foo</em>*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example313()
        {
            const string input = @"*foo *bar**";
            const string expected = @"<p><em>foo <em>bar</em></em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example314()
        {
            const string input = @"**foo***";
            const string expected = @"<p><strong>foo</strong>*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example315()
        {
            const string input = @"***foo* bar***";
            const string expected = @"<p><strong><em>foo</em> bar</strong>*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example316()
        {
            const string input = @"***foo** bar***";
            const string expected = @"<p><em><strong>foo</strong> bar</em>**</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example317()
        {
            const string input = @"*foo**bar***";
            const string expected = @"<p><em>foo</em><em>bar</em>**</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example318()
        {
            const string input = @"*foo****";
            const string expected = @"<p>*foo****</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example319()
        {
            const string input = @"*foo**

**foo*";
            const string expected = @"<p><em>foo</em>*</p>
<p>**foo*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example320()
        {
            const string input = @"*foo *bar**

**foo* bar*";
            const string expected = @"<p><em>foo <em>bar</em></em></p>
<p>**foo* bar*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example321()
        {
            const string input = @"**foo* bar*";
            const string expected = @"<p>**foo* bar*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example322()
        {
            const string input = @"*bar***";
            const string expected = @"<p><em>bar</em>**</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example323()
        {
            const string input = @"***foo*";
            const string expected = @"<p>***foo*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example324()
        {
            const string input = @"**bar***";
            const string expected = @"<p><strong>bar</strong>*</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example325()
        {
            const string input = @"***foo**";
            const string expected = @"<p>***foo**</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example326()
        {
            const string input = @"***foo *bar*";
            const string expected = @"<p>***foo <em>bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example327()
        {
            const string input = @"[link](/uri &quot;title&quot;)";
            const string expected = @"<p><a href=""/uri"" title=""title"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example328()
        {
            const string input = @"[link](/uri)";
            const string expected = @"<p><a href=""/uri"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example329()
        {
            const string input = @"[link]()";
            const string expected = @"<p><a href="""">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example330()
        {
            const string input = @"[link](&lt;&gt;)";
            const string expected = @"<p><a href="""">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example331()
        {
            const string input = @"[link](/my uri)";
            const string expected = @"<p>[link](/my uri)</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example332()
        {
            const string input = @"[link](&lt;/my uri&gt;)";
            const string expected = @"<p><a href=""/my%20uri"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example333()
        {
            const string input = @"[link](foo
bar)";
            const string expected = @"<p>[link](foo
bar)</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example334()
        {
            const string input = @"[link]((foo)and(bar))";
            const string expected = @"<p><a href=""(foo)and(bar)"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example335()
        {
            const string input = @"[link](foo(and(bar)))";
            const string expected = @"<p>[link](foo(and(bar)))</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example336()
        {
            const string input = @"[link](foo(and\(bar\)))";
            const string expected = @"<p><a href=""foo(and(bar))"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example337()
        {
            const string input = @"[link](&lt;foo(and(bar))&gt;)";
            const string expected = @"<p><a href=""foo(and(bar))"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example338()
        {
            const string input = @"[link](foo\)\:)";
            const string expected = @"<p><a href=""foo):"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example339()
        {
            const string input = @"[link](foo%20b&amp;auml;)";
            const string expected = @"<p><a href=""foo%20b%C3%A4"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example340()
        {
            const string input = @"[link](&quot;title&quot;)";
            const string expected = @"<p><a href=""%22title%22"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example341()
        {
            const string input = @"[link](/url &quot;title&quot;)
[link](/url &#39;title&#39;)
[link](/url (title))";
            const string expected = @"<p><a href=""/url"" title=""title"">link</a>
<a href=""/url"" title=""title"">link</a>
<a href=""/url"" title=""title"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example342()
        {
            const string input = @"[link](/url &quot;title \&quot;&amp;quot;&quot;)";
            const string expected = @"<p><a href=""/url"" title=""title &quot;&quot;"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example343()
        {
            const string input = @"[link](/url &quot;title &quot;and&quot; title&quot;)";
            const string expected = @"<p>[link](/url &quot;title &quot;and&quot; title&quot;)</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example344()
        {
            const string input = @"[link](/url &#39;title &quot;and&quot; title&#39;)";
            const string expected = @"<p><a href=""/url"" title=""title &quot;and&quot; title"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example345()
        {
            const string input = @"[link](   /uri
  &quot;title&quot;  )";
            const string expected = @"<p><a href=""/uri"" title=""title"">link</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example346()
        {
            const string input = @"[link] (/uri)";
            const string expected = @"<p>[link] (/uri)</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example347()
        {
            const string input = @"[foo &lt;bar attr=&quot;](baz)&quot;&gt;";
            const string expected = @"<p>[foo <bar attr=""](baz)""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example348()
        {
            const string input = @"[foo][bar]

[bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example349()
        {
            const string input = @"[*foo\!*][bar]

[bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title""><em>foo!</em></a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example350()
        {
            const string input = @"[foo][BaR]

[bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example351()
        {
            const string input = @"[Толпой][Толпой] is a Russian word.

[ТОЛПОЙ]: /url";
            const string expected = @"<p><a href=""/url"">Толпой</a> is a Russian word.</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example352()
        {
            const string input = @"[Foo
  bar]: /url

[Baz][Foo bar]";
            const string expected = @"<p><a href=""/url"">Baz</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example353()
        {
            const string input = @"[foo] [bar]

[bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example354()
        {
            const string input = @"[foo]
[bar]

[bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example355()
        {
            const string input = @"[foo]: /url1

[foo]: /url2

[bar][foo]";
            const string expected = @"<p><a href=""/url1"">bar</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example356()
        {
            const string input = @"[bar][foo\!]

[foo!]: /url";
            const string expected = @"<p>[bar][foo!]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example357()
        {
            const string input = @"[foo][]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example358()
        {
            const string input = @"[*foo* bar][]

[*foo* bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title""><em>foo</em> bar</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example359()
        {
            const string input = @"[Foo][]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">Foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example360()
        {
            const string input = @"[foo] 
[]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example361()
        {
            const string input = @"[foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example362()
        {
            const string input = @"[*foo* bar]

[*foo* bar]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title""><em>foo</em> bar</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example363()
        {
            const string input = @"[[*foo* bar]]

[*foo* bar]: /url &quot;title&quot;";
            const string expected = @"<p>[<a href=""/url"" title=""title""><em>foo</em> bar</a>]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example364()
        {
            const string input = @"[Foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><a href=""/url"" title=""title"">Foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example365()
        {
            const string input = @"\[foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p>[foo]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example366()
        {
            const string input = @"[foo*]: /url

*[foo*]";
            const string expected = @"<p>*<a href=""/url"">foo*</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example367()
        {
            const string input = @"[foo`]: /url

[foo`]`";
            const string expected = @"<p>[foo<code>]</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example368()
        {
            const string input = @"[[[foo]]]

[[[foo]]]: /url";
            const string expected = @"<p><a href=""/url"">[[foo]]</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example369()
        {
            const string input = @"[[[foo]]]

[[[foo]]]: /url1
[foo]: /url2";
            const string expected = @"<p><a href=""/url1"">[[foo]]</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example370()
        {
            const string input = @"[\[foo]

[\[foo]: /url";
            const string expected = @"<p><a href=""/url"">[foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example371()
        {
            const string input = @"[foo][bar]

[foo]: /url1
[bar]: /url2";
            const string expected = @"<p><a href=""/url2"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example372()
        {
            const string input = @"[foo][bar][baz]

[baz]: /url";
            const string expected = @"<p>[foo]<a href=""/url"">bar</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example373()
        {
            const string input = @"[foo][bar][baz]

[baz]: /url1
[bar]: /url2";
            const string expected = @"<p><a href=""/url2"">foo</a><a href=""/url1"">baz</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example374()
        {
            const string input = @"[foo][bar][baz]

[baz]: /url1
[foo]: /url2";
            const string expected = @"<p>[foo]<a href=""/url1"">bar</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example375()
        {
            const string input = @"![foo](/url &quot;title&quot;)";
            const string expected = @"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example376()
        {
            const string input = @"![foo *bar*]

[foo *bar*]: train.jpg &quot;train &amp; tracks&quot;";
            const string expected = @"<p><img src=""train.jpg"" alt=""foo &lt;em&gt;bar&lt;/em&gt;"" title=""train &amp; tracks"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example377()
        {
            const string input = @"![foo *bar*][]

[foo *bar*]: train.jpg &quot;train &amp; tracks&quot;";
            const string expected = @"<p><img src=""train.jpg"" alt=""foo &lt;em&gt;bar&lt;/em&gt;"" title=""train &amp; tracks"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example378()
        {
            const string input = @"![foo *bar*][foobar]

[FOOBAR]: train.jpg &quot;train &amp; tracks&quot;";
            const string expected = @"<p><img src=""train.jpg"" alt=""foo &lt;em&gt;bar&lt;/em&gt;"" title=""train &amp; tracks"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example379()
        {
            const string input = @"![foo](train.jpg)";
            const string expected = @"<p><img src=""train.jpg"" alt=""foo"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example380()
        {
            const string input = @"My ![foo bar](/path/to/train.jpg  &quot;title&quot;   )";
            const string expected = @"<p>My <img src=""/path/to/train.jpg"" alt=""foo bar"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example381()
        {
            const string input = @"![foo](&lt;url&gt;)";
            const string expected = @"<p><img src=""url"" alt=""foo"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example382()
        {
            const string input = @"![](/url)";
            const string expected = @"<p><img src=""/url"" alt="""" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example383()
        {
            const string input = @"![foo] [bar]

[bar]: /url";
            const string expected = @"<p><img src=""/url"" alt=""foo"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example384()
        {
            const string input = @"![foo] [bar]

[BAR]: /url";
            const string expected = @"<p><img src=""/url"" alt=""foo"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example385()
        {
            const string input = @"![foo][]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example386()
        {
            const string input = @"![*foo* bar][]

[*foo* bar]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""&lt;em&gt;foo&lt;/em&gt; bar"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example387()
        {
            const string input = @"![Foo][]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""Foo"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example388()
        {
            const string input = @"![foo] 
[]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example389()
        {
            const string input = @"![foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""foo"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example390()
        {
            const string input = @"![*foo* bar]

[*foo* bar]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""&lt;em&gt;foo&lt;/em&gt; bar"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example391()
        {
            const string input = @"![[foo]]

[[foo]]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""[foo]"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example392()
        {
            const string input = @"![Foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p><img src=""/url"" alt=""Foo"" title=""title"" /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example393()
        {
            const string input = @"\!\[foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p>![foo]</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example394()
        {
            const string input = @"\![foo]

[foo]: /url &quot;title&quot;";
            const string expected = @"<p>!<a href=""/url"" title=""title"">foo</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example395()
        {
            const string input = @"&lt;http://foo.bar.baz&gt;";
            const string expected = @"<p><a href=""http://foo.bar.baz"">http://foo.bar.baz</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example396()
        {
            const string input = @"&lt;http://foo.bar.baz?q=hello&amp;id=22&amp;boolean&gt;";
            const string expected = @"<p><a href=""http://foo.bar.baz?q=hello&amp;id=22&amp;boolean"">http://foo.bar.baz?q=hello&amp;id=22&amp;boolean</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example397()
        {
            const string input = @"&lt;irc://foo.bar:2233/baz&gt;";
            const string expected = @"<p><a href=""irc://foo.bar:2233/baz"">irc://foo.bar:2233/baz</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example398()
        {
            const string input = @"&lt;MAILTO:FOO@BAR.BAZ&gt;";
            const string expected = @"<p><a href=""MAILTO:FOO@BAR.BAZ"">MAILTO:FOO@BAR.BAZ</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example399()
        {
            const string input = @"&lt;http://foo.bar/baz bim&gt;";
            const string expected = @"<p>&lt;http://foo.bar/baz bim&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example400()
        {
            const string input = @"&lt;foo@bar.baz.com&gt;";
            const string expected = @"<p><a href=""mailto:foo@bar.baz.com"">foo@bar.baz.com</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example401()
        {
            const string input = @"&lt;foo+special@Bar.baz-bar0.com&gt;";
            const string expected = @"<p><a href=""mailto:foo+special@Bar.baz-bar0.com"">foo+special@Bar.baz-bar0.com</a></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example402()
        {
            const string input = @"&lt;&gt;";
            const string expected = @"<p>&lt;&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example403()
        {
            const string input = @"&lt;heck://bing.bong&gt;";
            const string expected = @"<p>&lt;heck://bing.bong&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example404()
        {
            const string input = @"&lt; http://foo.bar &gt;";
            const string expected = @"<p>&lt; http://foo.bar &gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example405()
        {
            const string input = @"&lt;foo.bar.baz&gt;";
            const string expected = @"<p>&lt;foo.bar.baz&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example406()
        {
            const string input = @"&lt;localhost:5001/foo&gt;";
            const string expected = @"<p>&lt;localhost:5001/foo&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example407()
        {
            const string input = @"http://google.com";
            const string expected = @"<p>http://google.com</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example408()
        {
            const string input = @"foo@bar.baz.com";
            const string expected = @"<p>foo@bar.baz.com</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example409()
        {
            const string input = @"&lt;a&gt;&lt;bab&gt;&lt;c2c&gt;";
            const string expected = @"<p><a><bab><c2c></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example410()
        {
            const string input = @"&lt;a/&gt;&lt;b2/&gt;";
            const string expected = @"<p><a/><b2/></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example411()
        {
            const string input = @"&lt;a  /&gt;&lt;b2
data=&quot;foo&quot; &gt;";
            const string expected = @"<p><a  /><b2
data=""foo"" ></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example412()
        {
            const string input = @"&lt;a foo=&quot;bar&quot; bam = &#39;baz &lt;em&gt;&quot;&lt;/em&gt;&#39;
_boolean zoop:33=zoop:33 /&gt;";
            const string expected = @"<p><a foo=""bar"" bam = 'baz <em>""</em>'
_boolean zoop:33=zoop:33 /></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example413()
        {
            const string input = @"&lt;33&gt; &lt;__&gt;";
            const string expected = @"<p>&lt;33&gt; &lt;__&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example414()
        {
            const string input = @"&lt;a h*#ref=&quot;hi&quot;&gt;";
            const string expected = @"<p>&lt;a h*#ref=&quot;hi&quot;&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example415()
        {
            const string input = @"&lt;a href=&quot;hi&#39;&gt; &lt;a href=hi&#39;&gt;";
            const string expected = @"<p>&lt;a href=&quot;hi'&gt; &lt;a href=hi'&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example416()
        {
            const string input = @"&lt; a&gt;&lt;
foo&gt;&lt;bar/ &gt;";
            const string expected = @"<p>&lt; a&gt;&lt;
foo&gt;&lt;bar/ &gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example417()
        {
            const string input = @"&lt;a href=&#39;bar&#39;title=title&gt;";
            const string expected = @"<p>&lt;a href='bar'title=title&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example418()
        {
            const string input = @"&lt;/a&gt;
&lt;/foo &gt;";
            const string expected = @"<p></a>
</foo ></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example419()
        {
            const string input = @"&lt;/a href=&quot;foo&quot;&gt;";
            const string expected = @"<p>&lt;/a href=&quot;foo&quot;&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example420()
        {
            const string input = @"foo &lt;!-- this is a
comment - with hyphen --&gt;";
            const string expected = @"<p>foo <!-- this is a
comment - with hyphen --></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example421()
        {
            const string input = @"foo &lt;!-- not a comment -- two hyphens --&gt;";
            const string expected = @"<p>foo &lt;!-- not a comment -- two hyphens --&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example422()
        {
            const string input = @"foo &lt;?php echo $a; ?&gt;";
            const string expected = @"<p>foo <?php echo $a; ?></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example423()
        {
            const string input = @"foo &lt;!ELEMENT br EMPTY&gt;";
            const string expected = @"<p>foo <!ELEMENT br EMPTY></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example424()
        {
            const string input = @"foo &lt;![CDATA[&gt;&amp;&lt;]]&gt;";
            const string expected = @"<p>foo <![CDATA[>&<]]></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example425()
        {
            const string input = @"&lt;a href=&quot;&amp;ouml;&quot;&gt;";
            const string expected = @"<p><a href=""&ouml;""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example426()
        {
            const string input = @"&lt;a href=&quot;\*&quot;&gt;";
            const string expected = @"<p><a href=""\*""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example427()
        {
            const string input = @"&lt;a href=&quot;\&quot;&quot;&gt;";
            const string expected = @"<p>&lt;a href=&quot;&quot;&quot;&gt;</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example428()
        {
            const string input = @"foo  
baz";
            const string expected = @"<p>foo<br />
baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example429()
        {
            const string input = @"foo\
baz";
            const string expected = @"<p>foo<br />
baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example430()
        {
            const string input = @"foo       
baz";
            const string expected = @"<p>foo<br />
baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example431()
        {
            const string input = @"foo  
     bar";
            const string expected = @"<p>foo<br />
bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example432()
        {
            const string input = @"foo\
     bar";
            const string expected = @"<p>foo<br />
bar</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example433()
        {
            const string input = @"*foo  
bar*";
            const string expected = @"<p><em>foo<br />
bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example434()
        {
            const string input = @"*foo\
bar*";
            const string expected = @"<p><em>foo<br />
bar</em></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example435()
        {
            const string input = @"`code  
span`";
            const string expected = @"<p><code>code span</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example436()
        {
            const string input = @"`code\
span`";
            const string expected = @"<p><code>code\ span</code></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example437()
        {
            const string input = @"&lt;a href=&quot;foo  
bar&quot;&gt;";
            const string expected = @"<p><a href=""foo  
bar""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example438()
        {
            const string input = @"&lt;a href=&quot;foo\
bar&quot;&gt;";
            const string expected = @"<p><a href=""foo\
bar""></p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example439()
        {
            const string input = @"foo
baz";
            const string expected = @"<p>foo
baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example440()
        {
            const string input = @"foo 
 baz";
            const string expected = @"<p>foo
baz</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example441()
        {
            const string input = @"hello $.;&#39;there";
            const string expected = @"<p>hello $.;'there</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example442()
        {
            const string input = @"Foo χρῆν";
            const string expected = @"<p>Foo χρῆν</p>";

            TestExample(input, expected);
        }

        [TestMethod]
        public void Example443()
        {
            const string input = @"Multiple     spaces";
            const string expected = @"<p>Multiple     spaces</p>";

            TestExample(input, expected);
        }

    }
}