import java.util.*;

class Product {
    int productId;
    String productName;
    String category;

    public Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    public void display() {
        System.out.println("ID: " + productId + ", Name: " + productName + ", Category: " + category);
    }
}

public class ECommerceSearch {

    public static int linearSearch(List<Product> products, int keyId) {
        for (int i = 0; i < products.size(); i++) {
            if (products.get(i).productId == keyId)
                return i;
        }
        return -1;
    }

    public static int binarySearch(List<Product> products, int keyId) {
        int left = 0, right = products.size() - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            int midId = products.get(mid).productId;

            if (midId == keyId)
                return mid;
            else if (midId < keyId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    public static void main(String[] args) {
        List<Product> productList = new ArrayList<>();
        productList.add(new Product(102, "Shoes", "Footwear"));
        productList.add(new Product(205, "T-shirt", "Apparel"));
        productList.add(new Product(303, "Phone", "Electronics"));
        productList.add(new Product(150, "Watch", "Accessories"));

        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter Product ID to search: ");
        int idToFind = scanner.nextInt();

        // Linear Search
        System.out.println("\n-- Linear Search --");
        int index = linearSearch(productList, idToFind);
        if (index != -1)
            productList.get(index).display();
        else
            System.out.println("Product not found!");

        // Binary Search
        System.out.println("\n-- Binary Search --");
        // sort before binary search
        productList.sort(Comparator.comparingInt(p -> p.productId));
        index = binarySearch(productList, idToFind);
        if (index != -1)
            productList.get(index).display();
        else
            System.out.println("Product not found!");

        scanner.close();
    }
}
