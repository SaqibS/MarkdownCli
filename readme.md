# MarkdownCli - A .Net Markdown Processor

## Overview

I wrote this tool when working on a team where we had traditionally written short one-page specs before implementing a feature. But it always felt like the docs were then placed somewhere else, on a web server. So I wanted to try writing the one-pagers in [Markdown](http://daringfireball.net/projects/markdown/syntax)-formatted text files, and checking these into source control, alongside the code.

The problem was that the original Markdown script is written in Perl, and I didn't want to make the entire team install Perl on their machines. So, I implemented this small .Net version. The executable itself does embarrassingly little - it makes use of the handy [MarkdownSharp](http://code.google.com/p/markdownsharp) library, originally developed for [StackOverflow](http://stackoverflow.com).

## Usage

* With no arguments, reads from standard input and writes to standard output.
* Markdown -? - Prints this message and exits.
* Markdown <input.txt> - Converts input.txt to HTML, and writes the result to standard output.
* Markdown <input.txt> <output.html> - Converts input.txt to HTML, and writes the result to output.html.

## Feedback

If you try this out, and particularly if you find it useful, please do get in touch. You can email "Me" at "SaqibShaikh.com".
