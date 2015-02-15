#include <fstream>

using namespace std;

class Node{
public:
  string data;
  Node *next;
  Node();
  Node(string);
  ~Node();
};
Node::Node(){
  data = "";
  next = NULL;
}

Node::Node(string s){
  data = s;
  next = NULL;
}

Node::~Node(){
  delete next;
}

class LinkedList{
public:
  Node* ListHead;
  LinkedList();
  ~LinkedList();
};

LinkedList::LinkedList(){
  ListHead = new Node("dummy");
}

LinkedList::~LinkedList(){
  delete ListHead;
}

int main(int argc, char *argv[]){
  LinkedList* list = new LinkedList();
    ifstream in;
    ofstream out;
    in.open(argv[1]);
    out.open(argv[2]);
    if (in != 0){
      string dataIn;
      while(in>>dataIn){
        out<<"listHead-->(";
        Node *newNode = new Node(dataIn);
        Node *walker = new Node();
        walker = list->ListHead;
        while (walker->next != NULL && walker->next->data < newNode->data)
          walker = walker->next;
        newNode->next = walker->next;
        walker->next = newNode;        
        Node *walker2 = new Node();
        walker2 = list->ListHead;
        int count = 0;
        while (walker2->next != NULL){
          if (count%5==4)
            out <<walker2->data<<", "<<walker2->next->data<<")\n-->(";
          else
            out <<walker2->data<<", "<<walker2->next->data<<")-->(";
        count++;
       walker2 = walker2->next;
    }//while
    out<<walker2->data<<", NULL)-->NULL"<<endl<<endl;
      }//while
  }//if
  in.close();
  out.close();
  return 0;
}
