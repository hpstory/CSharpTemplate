namespace CSharpTemplate.DataStructures
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode node = this.root;
            foreach (char c in word)
            {
                if (node.children[c - 'a'] == null)
                {
                    node.children[c - 'a'] = new TrieNode();
                }

                node = node.children[c - 'a'];
            }

            node.isWord = true;
        }

        public bool Search(string word)
        {
            TrieNode node = this.root;
            foreach (char c in word)
            {
                if (node.children[c - 'a'] == null)
                {
                    return false;
                }

                node = node.children[c - 'a'];
            }

            return node.isWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode node = this.root;
            foreach (char c in prefix)
            {
                if (node.children[c - 'a'] == null)
                {
                    return false;
                }

                node = node.children[c - 'a'];
            }

            return true;
        }

        [Test]
        public void Test()
        {
            var trie = new Trie();
            trie.Insert("foobarbaz");
            trie.Insert("bar");
            trie.Insert("foo");
            Assert.IsTrue(trie.Search("bar"));
            Assert.IsTrue(trie.StartsWith("fo"));
            Assert.IsFalse(trie.Search("baz"));
        }
    }

    public class TrieNode
    {
        public TrieNode[] children;

        public bool isWord;

        public TrieNode()
        {
            this.children = new TrieNode[26];
        }
    }
}
