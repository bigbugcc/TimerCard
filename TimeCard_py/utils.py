# -*- coding: utf-8 -*-
from Crypto.Random import random

def GetSchoolLocations():
    lng = str(102.86 + random.randint(7362, 9132) * 0.000001)
    lat = str(24.86 + random.randint(6747, 8677) * 0.000001)
    LocationStr = "{\"streetNumber\":\"\",\"street\":\"梁王路隧道\",\"district\":\"呈贡区\",\"city\":\"昆明市\",\"province\":\"云南省\",\"pois\":\"云南师范大学呈贡校区东区文聚公寓\",\"lng\":"+lng+",\"lat\":"+lat+",\"address\":\"呈贡区梁王路隧道云南师范大学呈贡校区东区文聚公寓\",\"text\":\"云南省-昆明市\",\"code\":\"\"}"
    return LocationStr