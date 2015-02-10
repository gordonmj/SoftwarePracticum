import java.io.*;
import java.util.Scanner;

class InsertionSort{
  public static LinkedList list = new LinkedList();

  public static void main(String[] args){
    try{
       File in = new File(args[0]);
       File out = new File(args[1]);
       FileOutputStream fOS = new FileOutputStream(out);
       BufferedWriter bW = new BufferedWriter(new OutputStreamWriter(fOS));

       Scanner sc = new Scanner(in).useDelimiter("\\s+?");
       while(sc.hasNext()){
    	   	String word = sc.next();
            if (word.equals("")) continue;
            bW.write("listHead-->(");
            Node newNode = new Node(word);
            System.out.println(word);
            Node walker = list.ListHead;
            while (walker.next != null && walker.next.data.compareTo(newNode.data) < 0){
              walker = walker.next;
           }//while
           newNode.next = walker.next;
           walker.next = newNode;
           Node walker2 = list.ListHead;
           int count = 0;
           while (walker2.next != null){
             if (count%5==4) bW.write(walker2.data+", "+walker2.next.data+")\n-->(");
             else bW.write(walker2.data+", "+walker2.next.data+")-->(");
             walker2 = walker2.next;
             count++;
           }
           bW.write(walker2.data+", NULL)-->NULL\n\n");
      }//while
       sc.close();
       bW.close();
   }//try
   catch (IOException e){
     e.printStackTrace();
   }
  }
}//class
