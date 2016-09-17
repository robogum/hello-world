#!python27
# -*- coding: utf-8 -*-

import pymssql

from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

from sqlalchemy import Column, Integer, String
class User(Base):
     __tablename__ = 'users'

     id = Column(Integer, primary_key=True)
     name = Column(String)
     fullname = Column(String)
     password = Column(String)

     def __repr__(self):
        return "<User(name='%s', fullname='%s', password='%s')>" % (
                             self.name, self.fullname, self.password)


#from sqlalchemy import 
#def _main():
#    con = pymssql.connect('127.0.0.1\SQLEXPRESS', user='sa', password='sa', database='SHKDB')
#    cur =con.cursor()
#    cur.execute(u'SELECT * FROM [M単位]'.decode('cp932'))
#    for row in cur.fetchall():
#        print row


def _create_table():
    """
    """
    from sqlalchemy import create_engine
    #mssql+pymssql://<username>:<password>@<freetds_name>/?charset=utf8
    conn_str = 'mssql+pymssql://sa:sa@<freetds_name>/?charset=utf8
    engine = create_engine('sqlite:///:memory:', echo=True)
def _main():
    #User.__table__
    print User()
    

if __name__ == '__main__':
    _main()
