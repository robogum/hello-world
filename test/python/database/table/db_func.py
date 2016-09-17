#!python27
# -*- coding:utf8 -*-

import pymssql

from sqlalchemy import create_engine


def get_db_engine(echo=True):
    """
    """

    engine = create_engine(

    con = pymssql.connect('127.0.0.1\SQLEXPRESS', user='sa', password='sa', database='SHKDB')
