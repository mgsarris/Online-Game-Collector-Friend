import re

sites = {"GOG":r"(?<=product.title\">)[\w\d\s:,\[\]\u2122\-\+\(\)\'\"]*(?=<\/span>)",
        "Steam":r"(?<=>)(.*)(?=<)",
        "Origin":r"(?<=alt=\")(.*)(?=\"\sng-src)"
        }

def searchThing(site,regexString):
    f = open('{0}.html'.format(site.lower()),encoding='utf8')
    output = open('{0}Data.txt'.format(site.lower()),'w',encoding="utf8")

    if site == "GOG":
        searchString = "product-title__text"
    elif site == "Steam":
        searchString = "gameListRowItemName"
    elif site == "Origin":
        searchString = "tealium-gametile-img"
    else:
        print("This is not supposed to show up, something horrible went wrong!")
        return

    i = 0

    for line in f:
        if searchString in line:
            # match = re.compile(regexString).match(line)
            # print(match)
            # print(p.search(line).group())
            output.write(re.compile(regexString).search(line).group()+"\n")
            i+=1

    print("You have {0} games on {1}!".format(i,site))
    f.close()
    output.close()

for page,regex in sites.items():
    searchThing(page,regex)
    # print("Now processing {0} with regex {1}".format(page,regex))
