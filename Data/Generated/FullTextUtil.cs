
using System;
using System.Collections.Generic;
using System.Text;

namespace Bar.Data
{
    public static class FullTextUtil
    {
        private static List<string> _Noises;
        const string _UniqueConst = "A9058702A49C4303808A452392BB479B";

        static FullTextUtil() 
        {
            _Noises = new List<string>(FullTextUtil.NoiseWords.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            _Noises = _Noises.ConvertAll<string>(delegate(string s) { return s.ToLower(); });
            _Noises.Sort();
        }

        public static string ReplaceNoiseWords(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                word = _UniqueConst;
            }
            else
            {
                word = word.ToLower();

                word = word.Trim();

                List<string> wordparts;
                char[] chars;
                bool isMultiWord = false;

                if (ContainsWhiteSpaceCharacters(word, out chars))
                {
                    isMultiWord = true;
                    wordparts = new List<string>(word.Trim().Split(chars, StringSplitOptions.RemoveEmptyEntries));

                    wordparts[0] = wordparts[0][0] == '"' ? wordparts[0].Substring(1) : wordparts[0];

                    int LWidx = wordparts.Count - 1;
                    int LCidx = wordparts[LWidx].Length - 1;

                    wordparts[LWidx] = (wordparts[LWidx][LCidx] == '"' ? wordparts[LWidx].Substring(0, LCidx) : wordparts[LWidx]);
                }
                else
                {
                    wordparts = new List<string>(word.Length);
                    wordparts.Add(word);
                }

                if (!IsValidPhrase(_Noises, wordparts))
                {
                    //Replace with a constant
                    word = _UniqueConst;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(word.Length);

                    sb.Append(wordparts[0]);
                    for (int i = 1; i < wordparts.Count; i++)
                    {
                        sb.Append(' ');
                        sb.Append(wordparts[i]);
                    }

                    if (isMultiWord)
                    {
                        sb.Insert(0, '"');
                        sb.Append('"');
                    }

                    word = sb.ToString();
                }
            }
            return word;
        }

        private static bool IsValidPhrase(List<string> noises, List<string> wordparts)
        {
            int wordCount = wordparts.Count;
            foreach (string word in wordparts)
            {
                foreach (string noise in noises)
                {
                    if (word.Equals(noise))
                    {
                        wordCount--;
                        break;
                    }
                }
            }

            return (wordCount > 0);
        }

        private static bool ContainsWhiteSpaceCharacters(string word, out char[] chars)
        {
            List<char> retval = new List<char>(0);
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsWhiteSpace(word[i]))
                {
                    retval.Add(word[i]);
                }
            }

            chars = retval.ToArray();

            return chars.Length > 0;
        }

        /// <summary>
        /// The words that SQL Server considers noise words.
        /// To add the list append a new word to the bottom.
        /// Note: the default list ends with a whitespace
        /// </summary>
        private static string NoiseWords =
@"about
1
after
2
all
also
3
an
4
and
5
another
6
any
7
are
8
as
9
at
0
be
$
because
been
before
being
between
both
but
by
came
can
come
could
did
do
does
each
else
for
from
get
got
has
had
he
have
her
here
him
himself
his
how
if
in
into
is
it
its
just
like
make
many
me
might
more
most
much
must
my
never
no
now
of
on
only
or
other
our
out
over
re
said
same
see
should
since
so
some
still
such
take
than
that
the
their
them
then
there
these
they
this
those
through
to
too
under
up
use
very
want
was
way
we
well
were
what
when
where
which
while
who
will
with
would
you
your
A
B
C
D
E
F
G
H
I
J
K
L
M
N
O
P
Q
R
S
T
U
V
W
X
Y
Z
 ";
    }
}