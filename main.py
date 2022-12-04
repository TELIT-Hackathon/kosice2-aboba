# %%
import csv
import requests
from bs4 import BeautifulSoup

if __name__ == '__main__':


    url = 'https://www.reality.sk/kosicky-kraj/virtualne-prehliadky/'

    req = requests.get(url)
    src = req.text
    with open("index.html", "w") as file:
        file.write(src)

    # with open("index.html") as file:
    #     src = file.read()
    soup = BeautifulSoup(src, "lxml")
    house_list = soup.find_all("div", class_="offer no-gutters")
    for item in house_list:
        p_a = item.find("p", class_="offer-price")

        if p_a:
            p_a = p_a.text.split()
            try:
                price = int(p_a[0] + p_a[1])

            except:
                price = None


        name = item.find('h2', class_="offer-title").text.strip()
        areas = item.find_all('span', class_="text-sm")


        num = areas[0].text.strip()
        if '0' < num <= '9':
            num = int(num[0])
        else:
            num = None

        squer = int(areas[2].text.strip().replace('| ', '').replace('m²', ''))
        if squer == 0:
            squer = None

        print(name)
        print(price)
        print(num)
        print(squer)









        print('---------------------------------------------')

# %%
